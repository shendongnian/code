    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.FindSymbols;
    using Microsoft.CodeAnalysis.MSBuild;
    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Razor;
    namespace TranslationSniffer
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Program().Go().Wait();
            }        
            public async Task Go()
            {
                // Roslyn!
                var ws = MSBuildWorkspace.Create();
                // Store the translation keys...
                List<string> used = new List<string>();
                List<string> delete = new List<string>();
                string solutionRoot = @"C:\_Code\PathToProject\";
                string sln = solutionRoot + "MySolution.sln";
                // Load the solution, and find all the cshtml Razor views...
                var solution = await ws.OpenSolutionAsync(sln);
                var mainProj = solution.Projects.Where(x => x.Name == "ConsumerWeb").Single();
                FileInfo[] cshtmls = new DirectoryInfo(solutionRoot).GetFiles("*.cshtml", SearchOption.AllDirectories);
                // Go through each Razor View - generate the equivalent CS and add to the project for compilation.
                var host = new RazorEngineHost(RazorCodeLanguage.Languages["cshtml"]);
                var razor = new RazorTemplateEngine(host);
                var cs = new CSharpCodeProvider();
                var csOptions = new CodeGeneratorOptions();
                foreach (var cshtml in cshtmls)
                {
                    using (StreamReader re = new StreamReader(cshtml.FullName))
                    {
                        try
                        {
                            // Let Razor do it's thang...
                            var compileUnit = razor.GenerateCode(re).GeneratedCode;
                            // Pull the code into a stringbuilder, and append to the main project:
                            StringBuilder sb = new StringBuilder();
                            using (StringWriter rw = new StringWriter(sb))
                            {
                                cs.GenerateCodeFromCompileUnit(compileUnit, rw, csOptions);
                            }
                            // Get the new immutable project
                            var doc = mainProj.AddDocument(cshtml.Name + ".cs", sb.ToString());
                            mainProj = doc.Project;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Compile fail for: {0}", cshtml.Name);
                            // throw;
                        }
                        continue;
                    }
                }
                // We now have a new immutable solution, as we have changed the project instance...
                solution = mainProj.Solution;
                // Pull out our application translation list (its in a static class called 'CMS'):
                var mainCompile = await mainProj.GetCompilationAsync();
                var mainModel = mainCompile.GetTypeByMetadataName("Resources.CMS");
                var translations = mainModel.GetMembers().Where(x => x.Kind == SymbolKind.Property).ToList();
                foreach (var translation in translations)
                {
                    var references = await SymbolFinder.FindReferencesAsync(translation, solution)                    ;
                    if (!references.First().Locations.Any())
                    {
                        Console.WriteLine("{0} translation is not used!", translation.Name);
                        delete.Add(translation.Name);
                    }
                    else
                    {
                        Console.WriteLine("{0} :in: {1}", translation.Name, references.First().Locations.First().Document.Name);
                        used.Add(translation.Name);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Used references {0}. Unused references: {1}", used.Count, delete.Count);
                return;
            }
        }
    }
