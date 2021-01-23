    public class HelperClass<T>
    {
        private int _someInt;
        void SomeMethod(int i)
        {
            _someInt = i;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new DefaultAssemblyResolver();
            var module = resolver.Resolve(Assembly.GetExecutingAssembly().FullName).MainModule;
            Console.WriteLine("For HelperClass<>");
            var helperClass = module.Import(typeof(HelperClass<>)).Resolve();
            var someMethod = helperClass.Methods[0];
            var someMethodBody = someMethod.Body;
            foreach (var instruction in someMethodBody.Instructions)
            {
                Console.WriteLine(
                    "{0}\t{1}\t{2}",
                    instruction.Offset,
                    instruction.OpCode.Code,
                    instruction.Operand == null ? "<null>" : string.Format("{0} / {1}", instruction.Operand.GetType().FullName, instruction.Operand.ToString()));
                var fieldReference = instruction.Operand as FieldReference;
                if (fieldReference != null)
                {
                    var fieldDefinition = fieldReference.Resolve();
                    Console.WriteLine(
                        "\t\tResolved field reference operand: {0} / {1}",
                        fieldDefinition.GetType().FullName,
                        fieldDefinition.ToString());
                }
            }
            Console.WriteLine("");
            Console.WriteLine("For HelperClass<int>");
            helperClass = module.Import(typeof(HelperClass<int>)).Resolve();
            someMethod = helperClass.Methods[0];
            someMethodBody = someMethod.Body;
            foreach (var instruction in someMethodBody.Instructions)
            {
                Console.WriteLine(
                    "{0}\t{1}\t{2}",
                    instruction.Offset,
                    instruction.OpCode.Code,
                    instruction.Operand == null ? "<null>" : string.Format("{0} / {1}", instruction.Operand.GetType().FullName, instruction.Operand.ToString()));
                var fieldReference = instruction.Operand as FieldReference;
                if (fieldReference != null)
                {
                    var fieldDefinition = fieldReference.Resolve();
                    Console.WriteLine(
                        "\t\tResolved field reference operand: {0} / {1}",
                        fieldDefinition.GetType().FullName,
                        fieldDefinition.ToString());
                }
            }
        }
    }
