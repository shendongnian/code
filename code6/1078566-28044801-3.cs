    public static class AsynchronousQueryExecutor
        {
            private static Action<object> m_OnFirstItemProcessed;
            public static void Call<T>(IEnumerable<T> query, Action<IEnumerable<T>> callback, Action<Exception> errorCallback, Action<object> OnFirstItemProcessed)
            {
                m_OnFirstItemProcessed = OnFirstItemProcessed;
                Func<IEnumerable<T>, IEnumerable<T>> func =
                    new Func<IEnumerable<T>, IEnumerable<T>>(InnerEnumerate<T>);
                IEnumerable<T> result = null;
                IAsyncResult ar = func.BeginInvoke(
                                    query,
                                    new AsyncCallback(delegate(IAsyncResult arr)
                                    {
                                        try
                                        {
                                            result = ((Func<IEnumerable<T>, IEnumerable<T>>)((AsyncResult)arr).AsyncDelegate).EndInvoke(arr);
                                        }
                                        catch (Exception ex)
                                        {
                                            if (errorCallback != null)
                                            {
                                                errorCallback(ex);
                                            }
                                            return;
                                        }
                                        //errors from inside here are the callbacks problem
                                        //I think it would be confusing to report them
                                        callback(result);
                                    }),
                                    null);
            }
            private static IEnumerable<T> InnerEnumerate<T>(IEnumerable<T> query)
            {
                int iCount = 0;
                foreach (var item in query) //the method hangs here while the query executes
                {
                    if (iCount == 0)
                    {
                        iCount++;
                        m_OnFirstItemProcessed(item);
                    }
                    yield return item;
                }
            }
        }
