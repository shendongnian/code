    public class FormulaReader : IFormulaReader
    {
        protected static readonly IToken EQUALIZE = new Token(TokenType.EQUALIZER, "=");
        protected static readonly IToken ADD = new Token(TokenType.MODIFIER, "+");
        protected static readonly IToken SUBTRACT = new Token(TokenType.MODIFIER, "-");
        protected static readonly IToken DIVIDE = new Token(TokenType.MODIFIER, "/");
        protected static readonly IToken MULTIPLY = new Token(TokenType.MODIFIER, "*");
        protected static readonly IToken GROUPSTART = new Token(TokenType.GROUPSTART, "(");
        protected static readonly IToken GROUPEND = new Token(TokenType.GROUPEND, ")");
        public IFormula Parse(string textRepresentation)
        {
            IList<IToken> tokenList = new List<IToken>()
            {
                EQUALIZE, ADD, SUBTRACT, DIVIDE, MULTIPLY, GROUPSTART, GROUPEND
            };
            IFormula formula = new Formula();
            IToken currentToken = new Token(TokenType.IDENTIFIER, "");
            bool equalizerFound = false;
            for (int i = 0, len = textRepresentation.Length; i < len; i++)
            {
                string item = textRepresentation[i].ToString();
                if (item == " ")
                {
                    continue;
                }
                IToken selectedToken = (from t in tokenList where string.Equals(t.Text, item) select t).FirstOrDefault();
                if (selectedToken == null)
                {
                    currentToken.Text += item;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(currentToken.Text))
                    {
                        // contains an identifier
                        formula.Add(currentToken, equalizerFound);
                    }
                    if (selectedToken.TokenType != TokenType.EQUALIZER)
                    {
                        formula.Add(selectedToken, equalizerFound);
                    }
                    else
                    {
                        equalizerFound = true;
                    }
                    currentToken = new Token(TokenType.IDENTIFIER, "");
                }
            }
            return formula;
        }
    }
