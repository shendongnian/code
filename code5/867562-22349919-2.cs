    public class Foo
    {
        public bool Result { get; set; }
        public static bool operator ==(Foo foo, Foo fooB)
        {
            return Equals(foo, fooB);
        }
        public static bool operator !=(Foo foo, Foo fooB)
        {
            return NotEquals(foo, fooB);
        }
        public static implicit operator bool(Foo foo)
        {
            return foo == null ? false : foo.Result;
        }
        private static bool Equals(Foo foo, Foo fooB)
        {
            if (object.Equals(foo, null))
            {
                return object.Equals(fooB, null);
            }
            if (object.Equals(fooB, null))
                return false;
            return foo.Result == fooB.Result;
        }
        private static bool NotEquals(Foo foo, Foo fooB)
        {
            return !Equals(foo, fooB);
        }
    }
