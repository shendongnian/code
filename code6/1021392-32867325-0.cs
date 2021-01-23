    public static class JustMockExtensions {
            public static FuncExpectation<T> PrintParams<T, T1>(this FuncExpectation<T> mock) {
                return mock.DoInstead<T1, T>((arg1, arg2) => {
                    string message = string.Empty;
                    message += Process(arg1);
                    message += Process(arg2);
                    Console.WriteLine(message);
                });
            }
    
            private static string Process<T>(T obj) {
                if (typeof(T).IsEnum) {
                    return Enum.GetName(typeof(T), obj);
                }
                return obj.ToString();
            }
        }
