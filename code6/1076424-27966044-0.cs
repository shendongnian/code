    public interface ISignaturizer
    {
        IGenerateSignature ToSignaturizer();
    }
    struct FooSignaturizer : IGenerateSignature, ISignaturizer{
        private readonly Foo _foo;
        public FooSignaturizer(Foo f) {
            _foo = f;
        }
        public string Generate() {
            return _foo.I + ":" + _foo.J;
        }
        public IGenerateSignature ToSignaturizer()
        {
            return (IGenerateSignature)this;
        }
    }
