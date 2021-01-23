    public static class Extensions
    {
        public static bool IsEmpty(this IEnumerable collection)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = collection.GetEnumerator();
                return !enumerator.MoveNext();
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
    }
