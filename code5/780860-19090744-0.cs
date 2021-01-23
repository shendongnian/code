        public interface IDisplayColumn<in T>
    {
        string Title { get; set; }
        int Order { get; set; }
        Func<T, object> Selector { get; }
    }
    
    public class DisplayColumn<T>: IDisplayColumn<T>
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public Func<T, object> Selector { get; set; }
    }
    
    public class ColumnSet<T>
    {
        public Type TypeHandled { get; set; }
        public IEnumerable<IDisplayColumn<T>> Columns { get; set; }
    }
    
    public static class ColumnSetTest
    {
        static ColumnSetTest()
        {
          IDisplayColumn<SettingsContext> testSingleColumn = new DisplayColumn<SettingsContext> { Title = "Test", Selector = x => x.Values };
    
            var columnSets = new List<ColumnSet<SettingsContext>>
            {
                new ColumnSet<SettingsContext>
                {
                    TypeHandled = typeof(SettingsContext),
                    Columns = new List<IDisplayColumn<SettingsContext>>
                    {
                        new DisplayColumn<SettingsContext> {Title = "Column 1", Order = 1, Selector = x => x.IsReadOnly },
                        new DisplayColumn<SettingsContext> {Title = "Column 2", Order = 2, Selector = x => x.IsSynchronized },
                        new DisplayColumn<SettingsContext> {Title = "Column 3", Order = 3, Selector = x => x.Keys }
                    }
                }
            };
        
}
}
