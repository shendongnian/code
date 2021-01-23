    public class CustomType 
    {
        [ThreadStatic]
        static object deserializationObject;
        public static IDisposable SetDeserializationObject(object deserializationObject)
        {
            return new DeserializationObjectValue(deserializationObject);
        }
        sealed class DeserializationObjectValue : IDisposable
        {
            object oldValue;
            public DeserializationObjectValue(object value)
            {
                this.oldValue = deserializationObject;
                deserializationObject = value;
            }
            int disposed = 0;
            public void Dispose()
            {
                // Dispose of unmanaged resources.
                if (Interlocked.Exchange(ref disposed, 1) == 0)
                {
                    Dispose(true);
                }                // Suppress finalization.  Since this class actually has no finalizer, this does nothing.
                GC.SuppressFinalize(this);
            }
            void Dispose(bool disposing)
            {
                if (disposing)
                {
                    // Free any other managed objects here.
                    deserializationObject = oldValue;
                    oldValue = null;
                }
            }
        }
        private CustomType(object deserializationObject)
        {
            if (deserializationObject != null)
            {
                // Handle as needed.
            }
        }
        public CustomType() : this(deserializationObject)
        {
        }
    }
