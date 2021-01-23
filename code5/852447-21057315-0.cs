    namespace MediaLibrary
    {
        public abstract class MediaStorage
        {
            internal readonly Mutex OpenLock;
            internal readonly Mutex AccessLock;
            
            public MediaStorage() {
                OpenLock = new Mutex(true, string.Format("{0} - OpenMutex",        
                    this.GetType().FullName));
                AccessLock = new Mutex(true, string.Format("{0} - OpenMutex",   
                    this.GetType().FullName));
                Data = new StringBuilder();
            }
    
            public StringBuilder Data { get; set; }
        }
    }
