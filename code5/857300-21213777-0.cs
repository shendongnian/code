    public class SoundexFilter : TokenFilter
    {
        private readonly ITermAttribute _termAttr;
        public SoundexFilter(TokenStream input)
            : base(input)
        {
            _termAttr = AddAttribute<ITermAttribute>();
        }
        public override bool IncrementToken()
        {
            if (input.IncrementToken())
            {
                string currentTerm = _termAttr.Term;
                // Any phonetic hash calculation will work here.
                var hash = Soundex.For(currentTerm);
                _termAttr.SetTermBuffer(hash);
                return true;
            }
            return false;
        }
    }
