    public class Evaluator
    {
        public void Eval(string Code)
        {
            Microsoft.CSharp.CSharpCodeProvider Provider = new Microsoft.CSharp.CSharpCodeProvider(); // Create an provider
            System.CodeDom.Compiler.ICodeCompiler Compiler = Provider.CreateCompiler(); // Create An Compiler
            System.CodeDom.Compiler.CompilerParameters Parameters = new System.CodeDom.Compiler.CompilerParameters(); // Create a parameters of the compiler
            Parameters.GenerateInMemory = true; // It should generate the compiled assembly in the memory
            System.CodeDom.Compiler.CompilerResults Results = Compiler.CompileAssemblyFromSource(Parameters, Code); //Compile it
            ///Now you just need to use reflection to call its methods
            object SomeClass = Results.CompiledAssembly.CreateInstance("ClassName"); //Name of the class you want to create an instance
            var Method = SomeClass.GetType().GetMethod("MethodName"); //Name of the Method you want to call
            Method.Invoke(SomeClass, null); // change null for the argument it needs
        }
    }
