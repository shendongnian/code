    string input = "aaaaa:Item:ID1222222:Item:ID3444444:Item:ID4555555";
                var response = new Dictionary<string, string>();
                string[] values = input.Split(':');
    
                for (int i = 1; i < values.Length; i++)
                {
                    if (!values[i].Contains("Item"))
                    {
                        // use the id as a unique key 
                        response.Add(values[i].Substring(0, 3), values[i]);
    
                    }
                }
    
                for (int i = 0; i < response.Count; i++)
                {
                    if (response.ContainsKey("ID1"))
                    {
                        Console.WriteLine(response["ID1"]);
                        Console.ReadLine();
                    }
                }
