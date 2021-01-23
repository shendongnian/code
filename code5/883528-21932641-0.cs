    private List<Article> GetArticles()
        {
            List<Article> arts = new List<Article>();
            arts.Add(new Article { Name = "Name1", Price = 2.80 });
            arts.Add(new Article { Name = "Name2", Price = 1.25 });
            arts.Add(new Article { Name = "Name3", Price = 9.32 });
            arts.Add(new Article { Name = "Name4", Price = 1.31 });
            arts.Add(new Article { Name = "Name5", Price = 0.80 });
            arts.Add(new Article { Name = "Name6", Price = 2.50 });
            arts.Add(new Article { Name = "Name7", Price = 0.50 });
            arts.Add(new Article {Name = "Total", Price = GetTotal(arts)});
            return arts;
        }
        private double GetTotal(List<Article> arts)
        {
            double Total = 0;
            foreach (Article art in arts)
            {
                Total += double.Parse(art.Price.ToString());
            }
            return Total;
        }
