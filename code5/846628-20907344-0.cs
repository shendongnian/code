       List<string> list = new List<string>();
                                list.Add("A");
                                list.Add("A");
                                list.Add("C");
                                list.Add("D");
                                list.Add("B");
                                list.Add("A");
                                list.Add("E");
                                list.Add("E");
    
                var distinct = from item in list
                               group item by item into x
                               where x.Count().Equals(1)
                               select x;
