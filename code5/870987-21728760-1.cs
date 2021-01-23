                public static TResult Do<T,TResult>(Func<T,TResult> action, T param, TimeSpan retryInterval, int retryCount = 3)
                {
                    for (int retry = 0; retry < retryCount; retry++)
                    {
                        try
                        {
                            return action(param);
                        }
                        catch (RetryOperationException)
                        {
                            Log.SaveFormat("Retry:{0} for action:{1}", "RetryProcessLog",retry, action.Method.Name);
                            Thread.Sleep(retryInterval);
                        }
                        catch (Exception ex)
                        {
                            Log.SaveFormat("Exception when retry:{0} error:{1}","RetryProcessLog",action.Method.Name,ex.Message);
                            return default(TResult);
                        }
                    }
        
                    return default(TResult);
                }
    
            public static T ExecuteGet<T>(string key)
            {
                var defaultReturnValue = default(T);
    
                cacheHit("ExecuteGet", key);
    
                var result = CacheClient.ExecuteGet<T>(CachePrefix + key);
    
                if (result.Success)
                {
                    return result.Value;
                }
                else if (result.StatusCode ==
                         CouchbaseStatusCode.StatusCodeExtension.ToInt(CouchbaseStatusCode.StatusCode.Busy)
                         ||
                         result.StatusCode ==
                         CouchbaseStatusCode.StatusCodeExtension.ToInt(CouchbaseStatusCode.StatusCode.TemporaryFailure)
                         ||
                         result.StatusCode ==
                         CouchbaseStatusCode.StatusCodeExtension.ToInt(CouchbaseStatusCode.StatusCode.SocketPoolTimeout)
                         ||
                         result.StatusCode ==
                         CouchbaseStatusCode.StatusCodeExtension.ToInt(CouchbaseStatusCode.StatusCode.UnableToLocateNode)
                         ||
                         result.StatusCode ==
                         CouchbaseStatusCode.StatusCodeExtension.ToInt(CouchbaseStatusCode.StatusCode.NodeShutdown)
                         ||
                         result.StatusCode ==
                         CouchbaseStatusCode.StatusCodeExtension.ToInt(CouchbaseStatusCode.StatusCode.OperationTimeout))
                {
                    Log.SaveFormat("Error:{0}:{2} in ExecuteGet for key:{1}. Going to throw RetryOperationException",
                                   "CacheManager", result.StatusCode, key,result.Message);
                    throw new RetryOperationException();
                }
    
                Log.SaveFormat("Error:{0}:{2} in ExecuteGet for key:{1}", "CacheManager", result.StatusCode, key,result.Message);
                return defaultReturnValue;
            }
