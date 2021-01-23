    class Program
    {
      static void Main( string[] args )
      {
          Test1();
      }
      private static void Test1()
      {
         //
         // Create an instance of type Foo and call Print
         //
         string FooSource = @"
            class Foo
            {
               public void Print()
               {
                  System.Console.WriteLine(""Hello from class Foo"");
               }
            }";
         Assembly assembly = CompileSource(FooSource);
         object myFoo = assembly.CreateInstance("Foo");
         // myFoo.Print(); // - Print not a member of System.Object
         // ((Foo)myFoo).Print(); // - Type Foo unknown
      }
    }
    private static Assembly CompileSource( string sourceCode )
    {
       CodeDomProvider cpd = new CSharpCodeProvider();
       CompilerParameters cp = new CompilerParameters();
       cp.ReferencedAssemblies.Add("System.dll");
       cp.ReferencedAssemblies.Add("ClassLibrary1.dll");
       cp.GenerateExecutable = false;
       // Invoke compilation.
       CompilerResults cr = cpd.CompileAssemblyFromSource(cp, sourceCode);
       return cr.CompiledAssembly;
    }
