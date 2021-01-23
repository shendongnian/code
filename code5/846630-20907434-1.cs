    List<string> list = new List<string>();
                            list.Add("A");
                            list.Add("A");
                            list.Add("C");
                            list.Add("D");
                            list.Add("B");
                            list.Add("A");
                            list.Add("E");
                            list.Add("E");
    
    var query = list.Except(list.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key));
