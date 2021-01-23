    public static class PropertyHelper
    {
        public static T Get<T, U>(ref T backingField, U initialValue = null)
            where T : class
            where U : class, T, new()
        {
            initialValue = initialValue ?? new U();
            return backingField ?? (backingField = initialValue);
        }
    }
    public class MyClass
    {
        private IList<int> myVar;
        public IList<int> MyProperty
        {
            get { return PropertyHelper.Get<IList<int>, List<int>>(ref myVar); }
            set { myVar = value; }
        }
        private IList<int> myVar2;
        public IList<int> MyProperty2
        {
            get { return PropertyHelper.Get(ref myVar2, new List<int>()); }
            set { myVar2 = value; }
        }
    }
