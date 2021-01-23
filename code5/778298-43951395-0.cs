    public static class Disposable
    {
        public static void Dispose(ref IDisposable obj)
        {
            if (obj!= null)
            {
                obj.Dispose();
                obj = null;
            }
        }
    }
