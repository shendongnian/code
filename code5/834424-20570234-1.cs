    var items = new[]
                {
                    new
                        {
                            Name = "Test",
                            Age = 20,
                            Test=25
                        },
                    new
                        {
                            Name = "Hello",
                            Age = 10,
                            Test=15
                        },
                    new
                        {
                            Name = "T2gdhest",
                            Age = 14,
                            Test=20
                        },
                    new
                        {
                            Name = "hai",
                            Age = 33,
                            Test=10
                        },
                    new
                        {
                            Name = "why not",
                            Age = 10,
                            Test=33
                        },
                };
           var match= items.MatchWithAnyProperty(10);
            foreach (var item in match)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
