    string[,] original = new string[4, 3] { { "apple", "price1", "2" }, { "orange", "price2", "10" }, { "Pineapple", "price5", "1" }, { "Kiwi", "price3", "5" } };
    var l = original.Cast<string>()
                    .Select((element, index) => new { element, index })
                    .GroupBy(x => x.index / 3)
                    .Select(x => new
                    {
                        Id = x.ElementAt(0).element,
                        Name = x.ElementAt(1).element,
                        Value = int.Parse(x.ElementAt(2).element)
                    })
                    .OrderBy(x => x.Value)
                    .Select(x => new string[] { x.Id, x.Name, x.Value.ToString() })
                    .ToArray(); 
