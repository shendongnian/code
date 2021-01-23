    public interface IHidden<T>
    {
        T HiddenPropery { set; }
    }
    public class SomeClass : IHidden<int>
    {
        private int someInt;
        public int HiddenPropery
        {
            get { return someInt; }
        }
        int IHidden<int>.HiddenPropery
        {
            set { someInt = value; }
        }
    }
