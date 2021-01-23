        public class Foo
        {
            private void Swizzle<T>(List<T> list)
            {
                Console.WriteLine("Sizzle");
            }
            private void Wibble(object o)
            {
                Console.WriteLine("Wibble");
            }
            public void DoSomething(object o)
            {
                 var ot = o.GetType();
                 if (ot.IsGenericType && ot.GetGenericTypeDefinition() == typeof(List<>))
                 {
                     this.GetType().GetMethod("Swizzle", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(ot.GetGenericArguments()[0])
                         .Invoke(this, new object[] { o });
                 }
                 else
                     this.Wibble(o);
            }
        }
    // Then usage
     var foo = new Foo();
     foo.DoSomething(new List<int>());
     foo.DoSomething(new object());
