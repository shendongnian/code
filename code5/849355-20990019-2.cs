    public class Parser
    {
        private Tokenizer tk;
        public Parser(string text)
        {
            this.tk = new Tokenizer(text);
        }
        public Dictionary<string, Value> Parse()
        {
            Stack<Dictionary<string, Value>> dictionaries = new Stack<Dictionary<string, Value>>();
    
            Token t;
                
            while ((t = tk.ReadToken()) != Token.End)
            {
                switch (t)
                {
                    case Token.KeyValuePair:
                        t = tk.ReadToken();
                        if (t != Token.OpenBracket)
                            throw new ParseError("{KeyValuePair} should be followed by a '{'");
                        dictionaries.Push(new Dictionary<string, Value>());
                        break;
                    case Token.CloseBracket:
                        if (dictionaries.Count > 1)
                            dictionaries.Pop();
                        break;
                    case Token.KeyOrValue:
                        string key = tk.TokenValue;
                        t = tk.ReadToken();
                        if (t != Token.Assign)
                            throw new ParseError("Key should be followed by a '='");
                        t = tk.ReadToken();
                        if (t == Token.KeyValuePair)
                        {
                            var value = new DictionaryValue();
                            dictionaries.Peek().Add(key, value);
                            dictionaries.Push(value.Values);
                        }
                        else if (t != Token.KeyOrValue)
                            throw new ParseError("Value expected after " + key + " =");
                        else
                        {
                            string value = tk.TokenValue;
                            dictionaries.Peek().Add(key, new StringValue(value));
                            t = tk.ReadToken();
                            if (t != Token.Next)
                                throw new ParseError("{next} expected after Key value pair (" + key + " = " + value + ")");
                        }
                        break;
                    case Token.Error:
                        break;
                    default:
                        break;
                }
            }
            return dictionaries.Peek();
        }
    
        private class Tokenizer
        {
            private string _data;
            private int currentIndex = 0;
            private string tokenValue;
    
            public string TokenValue
            {
                get { return tokenValue; }
            }
    
            public Tokenizer(string data)
            {
                this._data = data;
            }
    
            public Token ReadToken()
            {
                tokenValue = string.Empty;
                if (currentIndex >= _data.Length) return Token.End;
    
                char c = _data[currentIndex];
                if (char.IsWhiteSpace(c))
                {
                    currentIndex++;
                    return ReadToken();
                }
                else if (c == '{')
                {
                    if (TryReadBracketedToken("KeyValuePair"))
                    {
                        currentIndex++;
                        return Token.KeyValuePair;
                    }
                    else if (TryReadBracketedToken("next"))
                    {
                        currentIndex++;
                        return Token.Next;
                    }
                    else
                    {
                        currentIndex++;
                        return Token.OpenBracket;
                    }
                }
                else if (c == '}')
                {
                    currentIndex++;
                    return Token.CloseBracket;
                }
                else if (c == '=')
                {
                    currentIndex++;
                    return Token.Assign;
                }
                else
                {
                    StringBuilder valueBuilder = new StringBuilder();
                    while (currentIndex < _data.Length && !char.IsWhiteSpace(c))
                    {
                        valueBuilder.Append(c);
                        currentIndex++;
                        c = _data[currentIndex];
                    }
                    tokenValue = valueBuilder.ToString();
                    return Token.KeyOrValue;
                }
            }
    
            private bool TryReadBracketedToken(string token)
            {
                bool result = _data.Length > currentIndex + token.Length + 2
                            && _data.Substring(currentIndex + 1, token.Length + 1) == token + "}";
                if (result)
                {
                    currentIndex++;
                    currentIndex += token.Length;
                }
                return result;
            }
        }
    
        private enum Token
        {
            KeyValuePair,
            Next,
            OpenBracket,
            CloseBracket,
            Assign,
            KeyOrValue,
            End,
            Error
        }
    }
    
    public abstract class Value { }
    
    public class StringValue : Value
    {
        public string Value { get; private set; }
        public StringValue(string value)
        {
            this.Value = value;
        }
    }
    
    public class DictionaryValue : Value
    {
        public Dictionary<string, Value> Values { get; private set; }
        public DictionaryValue()
        {
            this.Values = new Dictionary<string, Value>();
        }
    }
    
    public class ParseError : Exception
    {
        public ParseError(string message)
            : base(message) { }
    }
