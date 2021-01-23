    interface IDeepCloneable<out T>
    {
        T DeepClone();
    }
    class SomeClass<T> : IDeepCloneable<T> where T : SomeClass<T>, new()
    {        
        // copy constructor
        protected SomeClass(SomeClass<T> source)
        {
            // copy members 
            x = source.x;
            y = source.y;
            ...
       }
        // implement the interface, subclasses overwrite this method to
        // call 'their' copy-constructor > because the parameter T refers
        // to the class itself, this will get you type-safe cloning when
        // calling 'anInstance.DeepClone()'
        public virtual T DeepClone()
        {
            // call copy constructor
            return new T();
        }
        ...
    }
    
