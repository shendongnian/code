    class SampleClass
    {
        public string Property { get; set; }
        public SampleClass()
        {
            Property = DateTime.Now.ToString();
        }
    }
    class Program
    {
        public static O Something<I, O>(params System.Linq.Expressions.Expression<Func<I, O>>[] funks)
            where I: new()
        {
            I i = new I();
            var output = funks[0].Compile()(i);
            return output;
        }
        static void Main(string[] args)
        {
            var dx= Something<SampleClass, string>(x => x.Property);
        }
    }
