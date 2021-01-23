    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace JsonExample
    {
        internal class Program
        {
            private static void Main()
            {
                const string json = @"
                    {
                        '1001': {
                            'name': 'Boots of Speed',
                            'plaintext': 'Slightly increases Movement Speed',
                            'group': 'BootsNormal',
                            'description': '<...'
                        }
                    }";
                var jObject = JsonConvert.DeserializeObject<JObject>(json);
                var plaintext = jObject["1001"]["plaintext"].Value<string>();
                Console.WriteLine(plaintext);
            }
        }
    }
