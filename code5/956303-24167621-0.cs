     public List<string> liste = new List<string> { "A", "D", "E" };
                public Dictionary<int, string> dic = new Dictionary<int, string>   
                {  
                {1, "A"},
                {2, "B"},
                {3, "c"},
                {4, "D"},
                {5, "E"},
                };
        
                 private void TriCustomer()
                 {
                    var query =  from x in dic
                                 join y in liste on x.Value equals y
                                 select new { x.Key, IsTrue = true };
        // check here 
                    foreach (var item in query)
                    {
                        MessageBox.Show(item.Key + " " + item.IsTrue);
                    }
                 }
