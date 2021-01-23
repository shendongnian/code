    public class TokenParser
    {
        private readonly Dictionary<Tokens, string> _tokens;
        private readonly Dictionary<Tokens, MatchCollection> _regExMatchCollection;
        private string _inputString;
        private int _index;
        public enum Tokens
        {
            UNDEFINED = 0,
            CREATE = 1,
            FIRST = 2,
            LAST = 3,
            BAR = 4,
            NAMED = 5,
            BAR_NAME = 6,
            WHITESPACE = 7,
            LPAREN = 8,
            RPAREN = 9,
            COMMA = 10,
            NUMBER = 11
        }
        public string InputString
        {
            set
            {
                _inputString = value;
                PrepareRegex();
            }
        }
        public TokenParser()
        {
            _tokens = new Dictionary<Tokens, string>();
            _regExMatchCollection = new Dictionary<Tokens, MatchCollection>();
            _index = 0;
            _inputString = string.Empty;
            _tokens.Add(Tokens.CREATE, "[Cc][Rr][Ee][Aa][Tt][Ee]");
            _tokens.Add(Tokens.FIRST, "[Ff][Ii][Rr][Ss][Tt]");
            _tokens.Add(Tokens.LAST, "[Ll][Aa][Ss][Tt]");
            _tokens.Add(Tokens.BAR, "[Bb][Aa][Rr][ \\t]");
            _tokens.Add(Tokens.NAMED, "[Nn][Aa][Mm][Ee][Dd]");
            _tokens.Add(Tokens.BAR_NAME, "[A-Za-z_][a-zA-Z0-9_]*");
            _tokens.Add(Tokens.WHITESPACE, "[ \\t]+");
            _tokens.Add(Tokens.LPAREN, "\\(");
            _tokens.Add(Tokens.RPAREN, "\\)");
            _tokens.Add(Tokens.COMMA, "\\,");
            _tokens.Add(Tokens.NUMBER, "[0-9]+");
        }
        private void PrepareRegex()
        {
            _regExMatchCollection.Clear();
            foreach (KeyValuePair<Tokens, string> pair in _tokens)
            {
                _regExMatchCollection.Add(pair.Key, Regex.Matches(_inputString, pair.Value));
            }
        }
        public void ResetParser()
        {
            _index = 0;
            _inputString = string.Empty;
            _regExMatchCollection.Clear();
        }
        public Token GetToken()
        {
            if (_index >= _inputString.Length)
                return null;
            foreach (KeyValuePair<Tokens, MatchCollection> pair in _regExMatchCollection)
            {
                foreach (Match match in pair.Value)
                {
                    if (match.Index == _index)
                    {
                        _index += match.Length;
                        return new Token(pair.Key, match.Value);
                    }
                    if (match.Index > _index)
                    {
                        break;
                    }
                }
            }
            _index++;
            return new Token(Tokens.UNDEFINED, string.Empty);
        }
        public PeekToken Peek()
        {
            return Peek(new PeekToken(_index, new Token(Tokens.UNDEFINED, string.Empty)));
        }
        public PeekToken Peek(PeekToken peekToken)
        {
            int oldIndex = _index;
            _index = peekToken.TokenIndex;
            if (_index >= _inputString.Length)
            {
                _index = oldIndex;
                return null;
            }
            foreach (KeyValuePair<Tokens, string> pair in _tokens)
            {
                var r = new Regex(pair.Value);
                Match m = r.Match(_inputString, _index);
                if (m.Success && m.Index == _index)
                {
                    _index += m.Length;
                    var pt = new PeekToken(_index, new Token(pair.Key, m.Value));
                    _index = oldIndex;
                    return pt;
                }
            }
            var pt2 = new PeekToken(_index + 1, new Token(Tokens.UNDEFINED, string.Empty));
            _index = oldIndex;
            return pt2;
        }
    }
    public class PeekToken
    {
        public int TokenIndex { get; set; }
        public Token TokenPeek { get; set; }
        public PeekToken(int index, Token value)
        {
            TokenIndex = index;
            TokenPeek = value;
        }
    }
    public class Token
    {
        public TokenParser.Tokens TokenName { get; set; }
        public string TokenValue { get; set; }
        public Token(TokenParser.Tokens name, string value)
        {
            TokenName = name;
            TokenValue = value;
        }
    }
