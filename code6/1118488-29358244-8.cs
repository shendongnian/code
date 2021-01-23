    public interface ISection<T>
        where T : ISectionItem
    {
        string Title { get; set; }
        IEnumerable<T> Items { get; set; }
    }
