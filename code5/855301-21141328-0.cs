    public static IEnumerable<T1> NotEmpty<T1>(IEnumerable<T1> argument, string message = null) where T1 : class
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(message);
                }
                if(!argument.Any())
                {
                    throw new ArgumentException(message);
                }
                return argument;
            }
