    public sealed class SubClass : BaseClass<SubClass>
    {
        protected override SubClass createNewInstanceStep2()
        {
            Console.WriteLine("In step 2");
            return this;
        }
    }
    public abstract class BaseClass<T> where T : BaseClass<T>, new()
        public T createNewInstance()
        {
            return createNewInstanceStep1();
        }
    
        //Each derived class implements their own version of this,
        //to handle copying any custom members contained in Properties.
        protected abstract T createNewInstanceStep2();
    
        protected T createNewInstanceStep1()
        {
            T newInstance = new T();
            ...
