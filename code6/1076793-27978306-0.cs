    class BaseClass : IDisposable
    {
        private WeakReference<BaseClass> myReference;
        private static List<WeakReference<BaseClass>> instances = new List<WeakReference>();
        
        public static UpdateClasses(MyData stuff)
        {
            foreach(var ref in instances)
            {
               BaseClass target;
               if (ref.TryGetTarget(out target))
               {
                   // code to update target here
               }
            }
        }
        protected BaseClass()
        {
           myReference = new WeakReference<BaseClass>(this,true);
           instances.Add(myReference);
        }
        ~BaseClass()
        {
           Dispose();
        }
        public void Dispose()
        {
           instances.Remove(myReference);
        }
    }
