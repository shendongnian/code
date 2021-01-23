    public class Foo
    {
        private readonly string[] names;
        private readonly string[] addresses;
        // Assuming you're using C# 6...
        private readonly ReadOnlyCollection<string> Names { get; }
        private readonly ReadOnlyCollection<string> Addresses { get; }
        public Foo()
        {
            names = ...;
            addresses = ...;
            Names = new ReadOnlyCollection<string>(names);
            Addresses = new ReadOnlyCollection<string>(addresses);
        }
    }
