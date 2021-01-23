    public static class Disposable
    {
        public static void TryDisposeAndClear<T>(ref T obj) where T : IDisposable
        {
            try
            {
                obj.Dispose();
            }
            catch { }
            obj = default(T);
        }
    }
