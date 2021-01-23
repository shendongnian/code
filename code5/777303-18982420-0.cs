    using System;
    
    class DeBugInfoAttribute : Attribute
    {
        public string Message { get; set; }
        public DeBugInfoAttribute(int i, string j, string k)
        {
            // to show we never get here!
            throw new NotImplementedException();
        }
    }
    
    [DeBugInfo(45, "Zara Ali", "12/8/2012", Message = "Return type mismatch")]
    static class Program
    {
        static void Main()
        {
            // this doesn't create the attribute, so no exception
            foreach (var data in typeof(Program).GetCustomAttributesData())
            {
                Console.WriteLine(data.AttributeType.Name);
                var parameters = data.Constructor.GetParameters();
                int i = 0;
                foreach (var arg in data.ConstructorArguments)
                {
                    Console.WriteLine("{0}: {1}",
                        parameters[i++].Name,
                        arg.Value);
                }
                foreach (var binding in data.NamedArguments)
                {
                    Console.WriteLine("{0}: {1}",
                        binding.MemberInfo.Name,
                        binding.TypedValue);
                }
            }
            // but this does: BOOM!
            var attribs = Attribute.GetCustomAttributes(typeof(Program));
        }
    }
