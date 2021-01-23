    public abstract class ColumnBase
    {
        public bool IsVisible { get; set; }
        public bool IsGroupBy { get; set; }
        public Type CLRType { get; set; }
        public abstract string GetGroupByString();
        public abstract string GetFilterString();
    }
