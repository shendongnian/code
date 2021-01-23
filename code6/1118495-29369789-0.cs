    public interface ISection
    {
        string Title { get; set; }
        IEnumerable<ISectionItem> Items { get; }
    }
    
    public class Section<T> : ISection 
        where T : ISectionItem
    {
        public string Title { get; set; }
        public LinkedList<T> Items { get; set; }
    
        IEnumerable<ISectionItem> ISection.Items
        {
            get {return Items.Cast<ISectionItem>();}
        }
    }
