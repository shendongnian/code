     public class MyClass : IDisposable
     {
            private static void MyStaticMethod()
            {
                // ....
            }
            public void MyInstanceMethod()
            {
                // ....
            }
            public void Dispose()
            {
                throw new NotImplementedException();
            }
     }
