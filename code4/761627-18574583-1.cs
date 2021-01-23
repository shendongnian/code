    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;
    using Roslyn.Compilers.Common;
    using Roslyn.Scripting;
    using Roslyn.Scripting.CSharp;
    //
    // To install Roslyn, run the following command in the Package Manager Console :  PM> Install-Package Roslyn
    //
    namespace WebScriptChecker
    {
        class Program
        {
            static void Error(params string[] errors)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var o in errors) { Console.Write(o.ToString()); }
                Console.Write(Environment.NewLine);
                Console.ForegroundColor = oldColor;
            }
            public static void Execute(string code) 
            {
                CommonScriptEngine engine = new ScriptEngine();
                Session session = engine.CreateSession();
                try {
                    Submission<object> submission = session.CompileSubmission<object>(code);
               
                    object result = submission.Execute();
                    bool hasValue;
                    ITypeSymbol resultType = submission.Compilation.GetSubmissionResultType(out hasValue);
                }
                catch (CompilationErrorException e) {
                    Error(e.Diagnostics.Select(d => d.ToString()).ToArray());
                }
                catch (Exception e) {
                    Error(e.ToString());
                }
            }
            static void Main(string[] args)
            {
                string sScriptCsx = @"
                    using System;
                        class Program
                        {
                            static void Main(string[] args)
                            {
                                Console.WriteLine(""Hello, World!"");
                            }
                        }
                    ";
                Execute(sScriptCsx);
                Console.WriteLine();
                Console.Write("Presser une touche pour continuer ... ");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
