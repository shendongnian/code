    namespace MediaLibrary
    {
        public class DataStore
        {
            #region "Static Class Logic"
            static DataStore instance;
    
            public static DataStore Instance {
                get {
                    return instance = instance ?? new DataStore();
                }
            }
            #endregion
    
            private readonly object openLock;
            private readonly object closeLock;
            Dictionary<Type, MediaStorage> mediaStorage;
    
            private DataStore() {
                openLock = new Object();
                closeLock = new Object();
                mediaStorage = new Dictionary<Type, MediaStorage>();
            }
    
            public MediaStorage Open(Type type) {
                lock (openLock) {
                    MediaStorage md = null;
                    bool alreadyCreated = mediaStorage.TryGetValue(type.GetType(), out md);
    
                    //has never been created.
                    if (md == null) {
                        md = (MediaStorage)Activator.CreateInstance(type, true);
                        mediaStorage.Add(type.GetType(), md);
                    }
    
                    //created or pulled from the dictionary, let's try to to get the object lock.
                    
                     md.OpenLock.WaitOne(-1);
    
                    //success, object obtained, don't forget everyone is blocked trying to get it,
                    //release as soon as possible.
                    return md;
                }
            }
    
            public void WriteData(Type type, string data) {
                //i assume the media is never removed if it's please protect this 
                //call with lock mechanism.
                MediaStorage media = GetMedia(type);
    
                lock (media.AccessLock) {
                    //simulate some delay
                    Thread.Sleep(1000);
                    media.Data.AppendFormat(
                        "thread:{0},data:{1}|\n", Thread.CurrentThread.ManagedThreadId, data);
                }
            }
    
            public string ReadData(Type type) {
                //i assume the media is never removed if it's please protect 
                //this call with lock mechanism.
                MediaStorage media = GetMedia(type);
                string data;
    
                lock (media.AccessLock) {
                    //simulate some delay
                    Thread.Sleep(new Random(Convert.ToInt32(DateTime.Now.Ticks)).Next(2000));
                    data = media.Data.ToString();
                }
    
                return data;
            }
    
            private MediaStorage GetMedia(Type mediaType) {
                MediaStorage md = null;
                mediaStorage.TryGetValue(mediaType.GetType(), out md);
                return md;
            }
    
            public void Close(MediaStorage media) {
                lock (closeLock) {
                    if (media.OpenLock.SafeWaitHandle.IsClosed) return;
                    media.OpenLock.ReleaseMutex();
                }
            }
        }
    }
