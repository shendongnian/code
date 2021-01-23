    public class FilteredStringList : Collection<string>
    {
        public new void Add(string item)
        {
            if (item.StartsWith("A"))
                base.Add(item);
        }
    }
