    public static class Example
    {
        public class State : IImmutableOf<State>
        {
            public State(int someInt, string someString)
            {
                SomeInt = someInt;
                SomeString = someString;
            }
            public readonly int SomeInt;
            public readonly string SomeString;
            public IImmutableBuilderFor<State> Mutate()
            {
                return new DefaultBuilderFor<State>(this);
            }
            public object Clone()
            {
                return base.MemberwiseClone();
            }
            public override string ToString()
            {
                return string.Format("{0}, {1}", SomeInt, SomeString);
            }
        }
        public static void Run()
        {
            var original = new State(10, "initial");
            var mutatedInstance = original.Mutate()
                .Set("SomeInt", 45)
                .Set(x => x.SomeString, "Hello SO")
                .Build();
            Console.WriteLine(mutatedInstance);
            mutatedInstance = original.Mutate()
                .Set(x => x.SomeInt, val => val + 10)
                .Build();
            Console.WriteLine(mutatedInstance);
        }
    }
