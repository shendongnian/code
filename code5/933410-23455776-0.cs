    class AsyncIO
    {
        void ReadFileAsync(string fileName)
        {
            AsyncOperationExt.Start(
                start => ReadFileAsyncHelper(fileName, start),
                result => Console.WriteLine("Result: " + result),
                error => Console.WriteLine("Error: " + error));
        }
        static IEnumerator<object> ReadFileAsyncHelper(string fileName, Action nextStep)
        {
            using (var stream = new FileStream(
                fileName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1024, useAsync: true))
            {
                IAsyncResult asyncResult = null;
                AsyncCallback asyncCallback = ar => { asyncResult = ar; nextStep(); };
                var buff = new byte[1024];
                while (true)
                {
                    stream.BeginRead(buff, 0, buff.Length, asyncCallback, null);
                    yield return Type.Missing;
                    int readBytes = stream.EndRead(asyncResult);
                    if (readBytes == 0)
                        break;
                    // process the buff
                }
            }
            yield return true;
        }
    }
    // ...
    // implement AsyncOperationExt.Start
    public static class AsyncOperationExt
    {
        public static void Start<TResult>(
            this Func<Action, IEnumerator<TResult>> start,
            Action<TResult> oncomplete,
            Action<Exception> onerror)
        {
            IEnumerator<TResult> enumerator = null;
            Action nextStep = () =>
            {
                try
                {
                    var current = enumerator.Current;
                    if (!enumerator.MoveNext())
                        oncomplete(current);
                }
                catch (Exception ex)
                {
                    onerror(ex);
                }
                enumerator.Dispose();
            };
            try
            {
                enumerator = start(nextStep);
            }
            catch (Exception ex)
            {
                onerror(ex);
                enumerator.Dispose();
            }
        }
    }
