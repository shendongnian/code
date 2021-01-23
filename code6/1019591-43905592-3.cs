    public static class Disposable
    {
        public static void DisposeIfNotNull(ref IDisposable disposableObject)
        {
            if (disposableObject != null)
            {
                disposableObject.Dispose();
                disposableObject = null;
            }
        }
    }
