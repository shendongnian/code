    public abstract class Token
    {
        private List<Token> _tokens { get; set; }
    
        public IEnumerable<Token> Tokens 
        { 
           get { return _tokens; } 
        }
    
        protected Token AddToken (Token token) 
        { 
           _tokens.Add(token); 
           return token; 
        }
    
        protected Token GetTokenAt(int index)
        {
            return _tokens[index];
        }
    }
