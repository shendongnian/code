        private static object SearchPositionUsingIndex(List<TagType<object>> tagList, string fieldTag)
        {
            // You would save this index, and build it only once, 
            // or rebuild it whenver something changes.
            // you could implement custom index modifications.
            var index = BuildIndex(tagList);
            int i;
            if (!index.TryGetValue(fieldTag, out i)) return null;
            if (i + 1 >= tagList.Count) return null;
            return tagList[i + 1].Position;
        }
        private static Dictionary<string, int> BuildIndex(List<TagType<object>> tagList)
        {
            var index = new Dictionary<string, int>();
            for (int i = 0; i < tagList.Count; i++)
            {
                var tag = tagList[i];
                if (!index.ContainsKey(tag.FieldTag)) index.Add(tag.FieldTag, i);
            }
            return index;
        }
