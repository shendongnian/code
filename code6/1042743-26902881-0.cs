        public string Get(string filterName, List<string> filterValues)
        {
            var concatFilter = string.Join("", GetItems(filterName, filterValues));
            return string.Format("(|{0})", concatFilter);
        }
        private IEnumerable<string> GetItems(string filterName, IEnumerable<string> filterValues)
        {
            return filterValues.Select(filterValue => Get(filterName, filterValue));
        }
        public string Get(string filterName, string filterValue)
        {
            return string.Format("({0}={1})", filterName, filterValue);
        }
