        private List<string> GetUniqueKeys(params string[] list)
        {
            var newList = new List<string>();
            newList.AddRange(list.Where(str => !string.IsNullOrEmpty(str)));
            return newList;
        }
