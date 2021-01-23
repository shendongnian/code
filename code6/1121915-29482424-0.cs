        public static Response Query<T1, T2, T3, T4, T5, T6, R1>(Func<T1, T2, T3, T4, T5, T6, Tuple<Response, R1>> method, T1 in1, T2 in2, T3 in3, T4 in4, T5 in5, T6 in6, ref R1 out1)
        {
            return QueryAll(() => method(in1, in2, in3, in4, in5, in6), ref out1);
        }
        private static Response QueryAll<R1>(Func<Tuple<Response, R1>> method, ref R1 out1)
        {
            try
            {
                Tuple<Response, R1> result;
                // Test if the method's class implements ICacheable
                if (method.GetType() is ICacheable)
                {
                    // Try to get the value from the cache if available
                    out1 = ((ICacheable)method.Target).Get<R1>(out1);
                    // If not null, return the value and exit
                    if (out1 != null)
                        return null;
                    else
                    {
                        // Value is null, but should be cached, so attempt to load to cache and return it
                        result = method();
                        out1 = result.Item2;
                        // If value from database is not null, save it in cache
                        if (out1 != null)
                            ((ICacheable)method.Target).Set<R1>(out1);
                        return result.Item1;
                    }
                }
                else
                {
                    // Get data from database
                    result = method();
                    out1 = result.Item2;
                    return result.Item1;
                }
            }
            catch (Exception exc)
            {
                CustomException exception = exc.ToCustomException();
                exception.Code = ResponseCodes.UnknownError;
                throw exception;
            }
        }
