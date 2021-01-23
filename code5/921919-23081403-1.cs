    public interface IMyProp
    {
        string this[int index] { get; }
    }
    public class MyClass : IMyProp
    {
        private List<string> list;
        string IMyProp.this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }
        // ctor etc.
        public IMyProp MyProp 
        {
            get
            {
                return this;
            }
        }
    }
