    public class Foo
    {
        public static IEnumerable<int> Bar()
        {
            yield return 1;
            Baz();
        }
    
        private static void Baz()
        {
            //there's no way for me to yield a second item out of Bar here
            //the best I can do is return an `IEnumerable` and have `Bar`
            //explicitly yield each of those items
        }
    }
