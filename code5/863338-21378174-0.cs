    public abstract class MyBaseClass<T> : where T : MyBaseClass<T>
    {
        public abstract T[] Search(string search);
    }
    public class DerivedClass : MyBaseClass<DerivedClass>
    {
        public override DerivedClass[] Search(string search)
        {
            return new DerivedClass[0];
        }
    }
