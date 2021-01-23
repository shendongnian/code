    public class Evaluator
    {
        public enum TokenType
        {
            Field,
            Comparer,
            Value,
            Operator,
            Parenthesis
        }
        public class Token
        {
            public TokenType TokenType;
            public string Value;
        }
        private string statement;
        private int cursor = 0;
        private Token curToken;
        private object target;
        public Evaluator(string statement, object target)
        {
            this.statement = statement;
        }
        public bool EvaluateStatement()
        {
            GetNextToken();
            bool value = EvaluateExpression();
            if (curToken != null && curToken.TokenType == TokenType.Operator)
            {
                var op = curToken;
                GetNextToken();
                var v2 = EvaluateExpression();
                if (op.Value == "AND")
                    return value && v2;
                else
                    return value || v2;
            }
            return value;
        }
        private bool EvaluateExpression()
        {
            if (curToken.TokenType == TokenType.Parenthesis)
            {
                GetNextToken();
                bool value = EvaluateExpression();
                GetNextToken(); // skip closing parenthesis
                return value;
            }
            var fieldName = curToken.Value;
            GetNextToken();
            var op = curToken.Value;
            GetNextToken();
            var targetValue = curToken.Value;
            GetNextToken();
            var fieldValue = GetFieldValue(target, fieldName);
            return EvaluateComparer(fieldValue, targetValue, op);
        }
        private bool EvaluateComparer(string left, string right, string op)
        {
            if (op == "=")
            {
                return left == right;
            }
            else if (op == "!=")
            {
                return left != right;
            }
            // add more ops here
            else
            {
                throw new Exception("Invalid op");
            }
        }
        /// <summary>
        /// Get the next token from the input string, put it into 'curToken' and advance 'cursor'.
        /// </summary>
        public void GetNextToken()
        {
            // skip spaces
            while (cursor < statement.Length || Char.IsWhiteSpace(statement[cursor]))
            {
                cursor++;
            }
            if (cursor >= statement.Length)
            {
                curToken = null;
            }
            var remainder = statement.Substring(cursor);
            if (remainder.StartsWith("Name"))
            {
                cursor += "Name".Length;
                curToken = new Token
                {
                    TokenType = TokenType.Field,
                    Value = "Name"
                };
            }
            else if (remainder.StartsWith("!="))
            {
                cursor += "!=".Length;
                curToken = new Token
                {
                    TokenType = TokenType.Field,
                    Value = "!="
                };
            }
            // etc.
            else
            {
                throw new Exception("Unexpected token");
            }
        }
        private string GetFieldValue(object target, string fieldName)
        {
            // trivial to implement with fixed set of field names
            throw new NotImplementedException();
        }
    }
