    void Test() {
        var foo = new Foo { I = 1, J = 2 };
        GetSignature(foo.AsIGenerateSignature());
    }
    void GetSignature(IGenerateSignature sig) {
        Console.Write(sig.Generate());
    }
    public static class GenerateSignatureExtensions
    {
        public static IGenerateSignature AsIGenerateSignature(this IGenerateSignature me)
        {
            return me;
        }
        public static IGenerateSignature AsIGenerateSignature(this Foo me)
        {
            return new FooSignaturizer(me);
        }
        public static IGenerateSignature AsIGenerateSignature(this Bar me)
        {
            return new BarSignaturizer(me);
        }
        //....
}
