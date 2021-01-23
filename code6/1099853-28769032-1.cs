    public static class ExtensionMethods
    {
        public static Bar ToBar(this Foo foo)
        {
            var bar = new Bar();
            bar.loadFromFooObject(foo);
            //you could also move the logic to convert from the Bar class in here
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
