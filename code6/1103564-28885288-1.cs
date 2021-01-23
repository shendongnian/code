    var items = new List<string>
                {
                    "Test 1",
                    "test 2"
                };
    object item = items;
    Console.WriteLine(string.Join(Environment.NewLine,(List<string>)item ));
    Console.ReadLine();
