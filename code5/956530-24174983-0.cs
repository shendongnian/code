     collection.GroupBy(item => new
                        {
                            Item1 = item.Item1.ToUpper()
                            Item2 = item.Item2.ToString().ToUpper()
                        }); 
