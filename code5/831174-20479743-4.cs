    class ListItemValueComparer : IEqualityComparer<ListItem>
    {
        public bool Equals(ListItem x, ListItem y)
        {
            return x.Value.Equals(y.Value);
        }
    
        public int GetHashCode(ListItem obj)
        {
            return obj.Value.GetHashCode();
        }
    }
