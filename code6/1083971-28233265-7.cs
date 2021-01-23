        public static IList<T> SplitStringUsing<T>(string source, 
            Func<string,T> parser,  
            string seperator = ",")
        {
            return source.Split(Convert.ToChar(seperator))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(parser)
                .ToList();
        }
