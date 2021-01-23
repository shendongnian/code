    public static class ObjectCollectionExtension
    {
        public static void AddAll<T>(this ComboBox.ObjectCollection self, IEnumerable<T> es)
        {
            foreach (var e in es)
                self.Add(e);
        }
    }
