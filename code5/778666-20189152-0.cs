        public class User 
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Venue
        {
            public int Id { get; set; }
            public string Address { get; set; }
        }
        public class Message
        {
            public string Text { get; set; }
            public int FromId { get; set; }
        }
        /* Deals with this SO question :
         * 
         * http://stackoverflow.com/questions/19023696/deserialize-dictionarystring-t
         */
        public static void PolymorphicKeyDrivenTest()
        {
            Console.Clear();
            Console.WriteLine("Polymorphic, key-driven Test");
            Console.WriteLine();
            string myJson = @"
            [
                {
                  ""%user%"" : { ""id"": 1, ""name"": ""Alex""} ,
                  ""%venue%"" : { ""id"": 465, ""address"": ""Thomas at 68th Street"" },
                  ""%message%"" : { ""text"": ""hello"", ""fromId"": 78 }
                },
                {
                  ""%user%"" : { ""id"": 2, ""name"": ""Carl""} ,
                  ""%message%"" : { ""text"": ""bye"", ""fromId"": 79 }
                }
            ]";
            Dictionary<string, object>[] parsed =
                JSON.Map(null as Dictionary<string, object>[]).
                    FromJson
                    (
                        myJson,
                        JSON.Map(default(Dictionary<string, object>)).
                            Using // Deal with the main issue raised by the SO question:
                            (
                                (outer, type, value) =>
                                    ((outer.Hash != null) && outer.Hash.ContainsKey("Name") ? (Func<object>)
                                    (() => new User { Id = (int)outer.Hash["Id"], Name = (string)outer.Hash["Name"] }) :
                                        ((outer.Hash != null) && outer.Hash.ContainsKey("Address") ? (Func<object>)
                                        (() => new Venue { Id = (int)outer.Hash["Id"], Address = (string)outer.Hash["Address"] }) :
                                            ((outer.Hash != null) && outer.Hash.ContainsKey("Text") ? (Func<object>)
                                            (() => new Message { FromId = (int)outer.Hash["FromId"], Text = (string)outer.Hash["Text"] }) :
                                                null
                                            )
                                        )
                                    )
                            ),
                        Sample_Revivers.CamelCaseToPascalCase,
                        Sample_Revivers.DoubleToInteger
                    );
            System.Diagnostics.Debug.Assert(parsed[0]["%user%"] is User);
            System.Diagnostics.Debug.Assert(parsed[0]["%venue%"] is Venue);
            System.Diagnostics.Debug.Assert(parsed[0]["%message%"] is Message);
            System.Diagnostics.Debug.Assert(parsed[1]["%user%"] is User);
            System.Diagnostics.Debug.Assert(parsed[1]["%message%"] is Message);
            Console.Write("Passed - Press a key...");
            Console.ReadKey();
        }
