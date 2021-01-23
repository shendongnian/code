    var assemblyName = new AssemblyName { Name = "Test" };
    
    var compilation = Compilation.Create(
        assemblyName.Name, new CompilationOptions(OutputKind.DynamicallyLinkedLibrary),
        new[] {
            SyntaxTree.ParseText(@"
    using System;
    using System.Linq;    
        
    public class C1
    {
        public void M1() 
        {
            new[] {1}.Select(_ => new {});
        }
    }")
        },
        new[] {
            MetadataReference.CreateAssemblyReference("mscorlib"),
            MetadataReference.CreateAssemblyReference("System.Core")
        });
    
    var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
        assemblyName, AssemblyBuilderAccess.RunAndSave);
    var moduleBuilder = assembly.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
    
    var emitResult = compilation.Emit(moduleBuilder);
    
    if (emitResult.Success)
    {
        assembly.Save(assemblyName.Name + ".dll"); //Error! Type '<>f__AnonymousType0' was not completed.
    }
    else
    {
        throw new NotImplementedException();
    }
