        public IEnumerable<string> PastEntries1
        {
            get
            {
                if(string.IsNullOrEmpty(textValue))
                {
                    return FieldDefString.PastEntries;
                }
                else 
                {
                    return FieldDefString.PastEntries.Where(x => x.StartsWith(textValue, StringComparison.OrdinalIgnoreCase));
                }
            }
        }
