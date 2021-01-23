        static void Main(string[] args)
        {
            Console.WriteLine(QueryBuilder.MatchMyModelFieldByStrategy<MyEntity>(
                new SearchItem { SearchStrategy = SearchStrategy.Contains, Value = "doe" }, _ => _.Name));
            Console.WriteLine(QueryBuilder.MatchMyModelFieldByStrategy<MyEntity>(
                new SearchItem { SearchStrategy = SearchStrategy.StartsWith, Value = "doe" }, _ => _.Name));
            Console.WriteLine(QueryBuilder.MatchMyModelFieldByStrategy<MyEntity>(
                new SearchItem { SearchStrategy = SearchStrategy.EndsWith, Value = "doe" }, _ => _.Name));
            Console.WriteLine(QueryBuilder.MatchMyModelFieldByStrategy<MyEntity>(
                new SearchItem { SearchStrategy = SearchStrategy.Equals, Value = "doe" }, _ => _.Name));
            Console.ReadLine();
        }
