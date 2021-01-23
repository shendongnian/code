        public static readonly ITokenFactory Default = (ITokenFactory)new VTokenFactory();
        protected internal readonly bool copyText;
        public VTokenFactory(bool copyText)
        {
            this.copyText = copyText;
        }
        public VTokenFactory()
            : this(false)
        {
        }
        public virtual VToken Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            VToken myToken = new VToken(source, type, channel, start, stop)
            {
                Line = line,
                Column = charPositionInLine
            };
            if (text != null)myToken.Text = text;
            else if (this.copyText && source.Item2 != null) myToken.Text = source.Item2.GetText(Interval.Of(start, stop));
            return myToken;
        }
        IToken ITokenFactory.Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            return (IToken)this.Create(source, type, text, channel, start, stop, line, charPositionInLine);
        }
        public virtual VToken Create(int type, string text)
        {
            return new VToken(type, text);
        }
        IToken ITokenFactory.Create(int type, string text)
        {
            return (IToken)this.Create(type, text);
        }
    }
