        private static void ToFormattedString(this object[] array)
        {
            var res = array.Select((item, index) => 
                                new { Index = index, Item = item is IEnumerable<object>
                                              ? (item as object[]).ToFormattedString()
                                              : item })
                           .Where(i => i.Item != null);
            return "{" + string.Join(", ", res.Select(r => r.Index.ToString() + ": " + r.Item.ToString())) + "}";
        }
