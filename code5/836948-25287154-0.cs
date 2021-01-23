        public static T RunWithOutRejected<T>(Func<T> func)
        {
            var result = default(T);
            bool hasException;
            do
            {
                try
                {
                    result = func();
                    hasException = false;
                }
                catch (COMException e)
                {
                    if (e.ErrorCode == -2147418111)
                    {
                        hasException = true;
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            } while (hasException);
            return result;
        }
    }
