    static class MethodDefinitionExtensions
    {
        public static bool CallsMethod(this MethodDefinition caller, 
            MethodDefinition callee)
        {
            return caller.Body.Instructions.Any(x => 
                x.OpCode == OpCodes.Call && x.Operand == callee);
        }
    }
    
    class Program
    {
        private static AssemblyDefinition _assembly = AssemblyDefinition.ReadAssembly(
            System.Reflection.Assembly.GetExecutingAssembly().Location);
    
        private static void Method1()
        {
            Method2();
        }
    
        private static void Method2()
        {
            Method1();
            Method3();
        }
    
        private static void Method3()
        {
            Method1();
        }
    
        private static IEnumerable<MethodDefinition> GetMethodsCalled(
            MethodDefinition caller)
        {
            return caller.Body.Instructions
                .Where(x => x.OpCode == OpCodes.Call)
                .Select(x => (MethodDefinition)x.Operand);
        }
    
        private static MethodDefinition GetMethod(string name)
        {
            TypeDefinition programType = _assembly.MainModule.Types
                .FirstOrDefault(x => x.Name == "Program");
            return programType.Methods.First(x => x.Name == name);
        }
    
        public static void Main(string[] args)
        {
            MethodDefinition method1 = GetMethod("Method1");
            MethodDefinition method2 = GetMethod("Method2");
            MethodDefinition method3 = GetMethod("Method3");
    
            Debug.Assert(method1.CallsMethod(method3) == false);
            Debug.Assert(method1.CallsMethod(method2) == true);
            Debug.Assert(method3.CallsMethod(method1) == true);
    
            Debug.Assert(GetMethodsCalled(method2).SequenceEqual(
                new List<MethodDefinition> { method1, method3 }));
        }
    }
