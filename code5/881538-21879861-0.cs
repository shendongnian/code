        public ICollection<object> Process(Stream stream)
        {
            Collection<object> collection = new Collection<object>();
            StreamReader reader = new StreamReader(stream);
            string pattern = @"set vrouter ""([\w-]+)""";
            while (!reader.EndOfStream)
            {
                var matches =
                    Regex.Matches(reader.ReadToEnd(), pattern)
                        .Cast<Match>().Where(m => m.Success)
                        .Select(m => m.Groups[1].Value)
                        .Distinct();
                foreach (var match in matches)
                {
                    var val = match + Environment.NewLine;
                    collection.Add(val);
                }
            }
            return collection;
        }
