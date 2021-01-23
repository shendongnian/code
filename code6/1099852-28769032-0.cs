    public static class ExtensionMethods
    {
        public static Bar ToBar(this Foo foo)
        {
            var bar = new Bar();
            bar.loadFromFooObject(foo);
            return bar;
        }
        //Overload for a collection of Foos (like Foo[] or List<Foo>)
        public static IEnumerable<Bar> ToBars(this IEnumerable<Foo> foos)
        {
            //Since ToBar is a Func<Foo, Bar>
            return foos.Select(ToBar);
            //alternate lambda syntax:  return foos.Select(foo => foo.ToBar());
        }
    }
