       public abstract class ColumnBase
    {
        public bool IsVisible { get; set; }
        public bool IsGroupBy { get; set; }
        public Type CLRType { get; set; }
        public virtual string GetGroupByString()
        {
            return "base string";
        }
        public abstract string GetFilterString();
    }
    public class ConcreteColumn : ColumnBase
    {
        public override string GetGroupByString()
        {
            return "concrete string";
        }
        public override string GetFilterString()
        {
            return "who owns the filter string?";
        }
    }
