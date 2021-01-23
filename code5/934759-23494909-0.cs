    public static class PropertyHelper
    {
        public static T Get<T>(ref T backingField) where T : class, new()
        {
            return backingField ?? (backingField = new T());
        }
    }
    public class MyClass
    {
        private List<int> myVar;
        public List<int> MyProperty
        {
            get { return PropertyHelper.Get(ref myVar); }
            set { myVar = value; }
        }
    }
