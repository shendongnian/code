    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.CodeDom.Compiler" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Reflection" #>
    <#@ import namespace="Microsoft.CSharp" #>
    <#+
    public class ImplementationGenerator
    {
       private Assembly interfaceAssembly;
       public ImplementationGenerator(string interfaceCsFileName, string[] additionalAssemblyNames = null)
       {
           List<string> assemblyNames = new List<string>(new string[] { "System.dll", "System.Core.dll" });
           if (null != additionalAssemblyNames)
           {
               assemblyNames.AddRange(additionalAssemblyNames);
           }
           CompilerParameters parameters = new CompilerParameters(assemblyNames.ToArray())
           {
               GenerateExecutable = false,
               IncludeDebugInformation = false,
               GenerateInMemory = true
           };
           CSharpCodeProvider csProvider = new CSharpCodeProvider();
           CompilerResults interfaceResults = csProvider.CompileAssemblyFromFile(parameters, interfaceCsFileName);
           if (interfaceResults.Errors.HasErrors)
           {
               string errorMessage = "The compiler returned the following errors:\n";
               foreach (CompilerError error in interfaceResults.Errors)
               {
                   errorMessage += "\t"+error.ErrorText+"\n";
               }
               throw new Exception(errorMessage);
           }
           interfaceAssembly = interfaceResults.CompiledAssembly;
       }
       public void Generate()
       {
           //use reflection to parse interfaceAssembly methods and generate the implementation
       }
    }
