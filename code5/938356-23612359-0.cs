    class Manager
    {
        //A WeakReference prevents memory leaks when you dispose of managers in another place
        private static readonly List<WeakReference<Manager>> Instances 
                 = new List<WeakReference<Manager>>();
    
        public static void AbortAll()
        {
            foreach (var weakReference in Instances)
            {
                Manager current;
                if (weakReference.TryGetTarget(out current))
                    current.Abort();
            }
            Instances.Clear();
        }
    
        private void Abort()
        {
            //...
        }
    
        public Manager()
        {
            //...
            Instances.Add(new WeakReference<Manager>(this));
        }
    }
