    namespace ConsoleApplication1
    {
        class Class1
        {
            public T GetPost<T>(string s) where T : new()
            {
                if (typeof(T)== typeof(User))
                {
                    var result = new User();
                    result.Password = "some";
                    return (T)(object)result;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
