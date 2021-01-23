    class Foo
    {
        private static List<string>[] myList;
        static Foo()
        {
            myList = Enumerable.Range(0, 1000)
                .Select(x => new List<string>(500)).ToArray();
        }
    }
