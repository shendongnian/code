    public class Subscriber
    {
        public string Name { get; set; }
    
        // For compare
        public override bool Equals(object obj) { return string.Equals(this.Name, ((Subscriber)obj).Name); }
        public override int GetHashCode() { return this.Name.GetHashCode(); } 
    }
    
    public class SomeData
    {
        public string Content { get; set; }
    
        // For compare
        public override bool Equals(object obj) { return string.Equals(this.Content, ((SomeData)obj).Content); }
        public override int GetHashCode() { return this.Content.GetHashCode(); } 
    }
    
    public class InputData
    {
        public Subscriber Subscribers { get; set; }
        public IEnumerable<SomeData> DataItems { get; set; }
    
        // Should always initialize an empty collection
        public InputData() { this.DataItems = new List<SomeData>(); }
    }
    
    public class QueueItem
    {
        public IEnumerable<Subscriber> Subscribers { get; set; }
        public IEnumerable<SomeData> DataItems { get; set; }
    
        // Should always initialize an empty collection
        public QueueItem() { this.Subscribers = new List<Subscriber>(); this.DataItems = new List<SomeData>(); }
    }
    
    public class DataItemsEqualityComparer : EqualityComparer<IEnumerable<SomeData>>
    {
    
        public override bool Equals(IEnumerable<SomeData> x, IEnumerable<SomeData> y)
        {
            return Enumerable.SequenceEqual(x, y);
        }
    
        public override int GetHashCode(IEnumerable<SomeData> obj)
        {
            return obj.Select(i => i.GetHashCode()).Sum().GetHashCode();
        }
    }
