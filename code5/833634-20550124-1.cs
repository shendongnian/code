    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""good"" : {
                    ""company"": ""self"",
                    ""code"": [
                        ""4581 "",
                        ""6732 "",
                        ""9121"",
                        ""9999 "",
                        ""5947 "",
                        ""8322 "",
                        ""8351 "",
                        ""7335 "",
                        ""9999 "",
                        ""4225 "",
                        ""8399 ""
                    ]
                },
                ""bad"" : -1
            }";
            Wrapper wrapper =
                JsonConvert.DeserializeObject<Wrapper>(json, 
                    new EmployerNormalizedConverter());
            DumpEmployer("good", wrapper.good);
            DumpEmployer("bad", wrapper.bad);
        }
        private static void DumpEmployer(string prop, EmployerNormalized emp)
        {
            Console.WriteLine(prop);
            if (emp != null)
            {
                Console.WriteLine("  company: " + emp.company);
                Console.WriteLine("  codes: " + 
                    string.Join(", ", emp.code.Select(c => c.ToString())));
            }
            else
                Console.WriteLine("  (null)");
        }
        public class Wrapper
        {
            public EmployerNormalized good { get; set; }
            public EmployerNormalized bad { get; set; }
        }
        public class EmployerNormalized
        {
            public string company;
            public List<int> code;
        }
    }
