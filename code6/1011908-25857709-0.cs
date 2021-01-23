    10,20
    1
    2
    10,50
    2
    var parents = new List<Parent>
                {
                    new Parent
                    {
                        Id = 1,
                        Children =
                            new List<Child>
                            {
                                new Child {SomeValue = 10},
                                new Child {SomeValue = 20},
                                new Child {SomeValue = 40}
                            }
                    },
                    new Parent
                    {
                        Id = 2,
                        Children =
                            new List<Child>
                            {
                                new Child {SomeValue = 10},
                                new Child {SomeValue = 20},
                                new Child {SomeValue = 50}
                            }
                    }
                };
    
                var val1 = 10;
                var val2 = 20;
                var query = from a in parents
                    from b in a.Children
                    where b.SomeValue == val1
                    select a;
    
                var query2 = from a in parents
                            from b in a.Children
                            where b.SomeValue == val2
                            select a;
    
                Console.WriteLine("10,20");
                foreach(var parent in query.ToList().Intersect(query2.ToList()))
                    Console.WriteLine(parent.Id);
    
                val1 = 10;
                val2 = 50;
    
                Console.WriteLine("10,50");
                foreach (var parent in query.ToList().Intersect(query2.ToList()))
                    Console.WriteLine(parent.Id);
