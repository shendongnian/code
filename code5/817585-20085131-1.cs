        public static void Foo<T>(List<T> list)
        {
            list.ForEach(s => Console.WriteLine(s));
        }
    and call `TestMe` then:
        TestMe<string>(Foo);     //outputs: 123
