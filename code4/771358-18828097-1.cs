    internal class Program
    {
        private static void Main ()
        {
            var obj = new Dictionary<string, string> {
                { "SessionID", "123456" },
                { "HTTP_VERB", "POST" },
                { "HTTPVERSION", "1" },
            };
            var settings = new JsonSerializerSettings {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertiesContractResolver()
            };
            string strCamel = JsonConvert.SerializeObject(obj, settings);
            Console.WriteLine("camelCase: \n" + strCamel);
            Console.WriteLine(strCamel.Contains("httP_VERB") ? "Something is wrong with this camel case" : "Success");
            settings.ContractResolver = new CamelCasePropertiesContractResolver(IdentifierCase.Pascal);
            string strPascal = JsonConvert.SerializeObject(obj, settings);
            Console.WriteLine("PascalCase: \n" + strPascal);
            Console.ReadKey();
        }
    }
