    public interface IDisplayColumn<in T>
    {
        string Title { get; set; }
        int Order { get; set; }
        Func<T, object> Selector { get; }
    }
    public class DisplayColumn<T> : IDisplayColumn<T>
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public Func<T, object> Selector { get; set; }
    }
    public interface IColumnSet<out T>
    {
        Type TypeHandled { get; }
        IEnumerable<T> Columns { get; }
    }
    public class ColumnSet<T> : IColumnSet<IDisplayColumn<T>>
    {
        public Type TypeHandled
        {
            get
            {
                return typeof(T);
            }
        }
        public IEnumerable<IDisplayColumn<T>> Columns { get; set; }
    }
