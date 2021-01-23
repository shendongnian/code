        public List<string> FindMatchingItems(string filePath, string id)
        {
            var json = File.ReadAllText(filePath);
            var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
            var result = rootObject.outer.First().inner.First(i => i.key == id).items.Select(item => item.itemid).ToList();
            return result;
        }
