    public class Foo
    {
        public bool Result { get; set; }
        public static implicit operator bool(Foo foo)
        {
            return !object.ReferenceEquals(foo, null) && foo.Result;
        }
    }
