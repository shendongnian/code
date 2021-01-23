    List<Tuple<int, double>> Ratings = new List<Tuple<int, double>>();
        
                        Ratings.Add(new Tuple<int, double>(1, 4.5));
                        Ratings.Add(new Tuple<int, double>(4, 1.0));
                        Ratings.Add(new Tuple<int, double>(3, 5.0));
                        Ratings.Add(new Tuple<int, double>(2, 2.5));
        
                        var list = Ratings.OrderByDescending(c => c.Item2).ToList();
