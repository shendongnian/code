    List<string> list = new List<string>();
                            list.Add("A");
                            list.Add("A");
                            list.Add("C");
                            list.Add("D");
                            list.Add("B");
                            list.Add("A");
                            list.Add("E");
                            list.Add("E");
    
    var query = list
                .Aggregate("", (total, next) => total.Contains(next) ? total : total += next)
                .ToCharArray().ToList();
