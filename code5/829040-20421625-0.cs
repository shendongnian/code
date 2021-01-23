    public abstract class AOverClass<T> : IBase where T : IBase
    {
        public AOverClass(T pObject)  // an "in" parameter of type T here! :-(
        {
            //Some code
        }
        //Some code...
    }
