    public abstract class BaseClass
    {
        public IList SomeList { get; set; }
    }
    public class ChildClass<T> : BaseClass 
    {
        public new List<T> SomeList
        {
            get { return (List<T>) base.SomeList; }
            set { base.SomeList = value; }
        }
    }
