            var articles = new List<Article>(new[]
            {
                new Article(){Title="Article A", PostDate=DateTime.Today.AddMonths(-1)},
                new Article(){Title="Article A", PostDate=DateTime.Today.AddMonths(-2)},
                new Article(){Title="Article A", PostDate=DateTime.Today.AddMonths(-3)},
                new Article(){Title="Article A", PostDate=DateTime.Today.AddYears(-1)},
                new Article(){Title="Article A", PostDate=DateTime.Today.AddYears(-1).AddMonths(-1)},
                new Article(){Title="Article A", PostDate=DateTime.Today.AddYears(-1).AddMonths(-2)},
                new Article(){Title="Article A", PostDate=DateTime.Today.AddYears(-1).AddMonths(-3)},
            });
            var set = from article in articles
                      group article by new { article.PostDate.Year, article.PostDate.Month }
                      into byMonthYear
                      group byMonthYear by byMonthYear.Key.Year
                      into byYear
                      select byYear;
            
            
