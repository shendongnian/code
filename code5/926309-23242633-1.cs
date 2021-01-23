    public class MyArbitraries
    {
        public static Arbitrary<string> String()
        {
            var nulls = Any.Value<string>(null);
            var nonnulls = Arb.Default.String().Generator;
            return Any.GeneratorIn(nulls, nonnulls).ToArbitrary;
        }
    }
