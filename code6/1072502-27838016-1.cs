    class Foo
    {
        private Self me = new Self(); // Equivalent to new Self("me")
        public void SomeMethod()
        {
            // Can't use the default here, as it would be "SomeMethod".
            // But we can use nameof...
            var joe = new Self(nameof(joe));
        }
    }
