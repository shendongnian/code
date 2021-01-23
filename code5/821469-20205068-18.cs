    //This code compiles fine in .NET 4.5 and runs without throwing any errors.
    internal class Program
    {
        public static void Main()
        {
            var item = new Baz();
            var inner = new List<Baz>();
            inner.Add(item);
            IEnumerable<IEnumerable<Foo>> data = inner;
            foreach (Foo foo in data)
            {
                foo.Bar();
            }
        }
    }
    public class Foo
    {
        public void Bar()
        {
        }
    }
    public class Baz : Foo, IEnumerable<Foo>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator<Foo> IEnumerable<Foo>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
