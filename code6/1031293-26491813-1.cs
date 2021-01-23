    public class CollectionContainsConverter : IValueConverter
    {
        public IEnumerable<object> Collection { get; set; } //This is actually a DP
    
        public object Convert(...)
        {
            return Collection.Contains(value);
            // or possibly, to allow for the Object.Equals override
            return Collection.Any(o => o.Equals(value));
        }
    
        public object ConvertBack(...)
        {
             return Binding.DoNothing;
        }
    }
