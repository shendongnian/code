    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            [
                { 
                    ""my property"" : ""foo"",
                    ""my-other-property"" : ""bar"",
                },
                { 
                    ""(myProperty)"" : ""baz"",
                    ""myOtherProperty"" : ""quux""
                },
                { 
                    ""MyProperty"" : ""fizz"",
                    ""MY_OTHER_PROPERTY"" : ""bang""
                }
            ]";
            List<MyClass> list = JsonConvert.DeserializeObject<List<MyClass>>(json);
            foreach (MyClass mc in list)
            {
                Console.WriteLine(mc.MyProperty);
                Console.WriteLine(mc.MyOtherProperty);
            }
        }
    }
