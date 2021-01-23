    partial class FooTable 
    {
        private static readonly CompiledExpression<FooTable,string> prefixExpression
                = DefaultTranslationOf<FooTable>.Property(e => e.Prefix).Is(e => e.Foo.Substring(0, 5));
        public string Prefix
        {
            get { return prefixExpression.Evaluate(this); }
        }
    }
