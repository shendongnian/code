    /// <summary>
    /// [CustomAuthorize(Roles = "A & (!B | C) ^ D")]
    /// </summary>
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        /*
         *  Exp -> SubExp '&' SubExp // AND
         *  Exp -> SubExp '|' SubExp // OR
         *  Exp -> SubExp '^' SubExp // XOR
         *  SubExp -> '(' Exp ')'
         *  SubExp -> '!' Exp        // NOT
         *  SubExp -> RoleName
         *  RoleName -> [a-z]
         */
        private const char TokenSeparator = ' ';
        private const char TokenAnd = '&';
        private const char TokenOr = '|';
        private const char TokenXor = '^';
        private const char TokenNot = '!';
        private const char TokenParentheseOpen = '(';
        private const char TokenParentheseClose = ')';
        abstract class Node
        {
            public abstract bool Eval(IPrincipal principal);
        }
        abstract class UnaryNode : Node
        {
            private readonly Node _expression;
            public Node Expression
            {
                get { return _expression; }
            }
            protected UnaryNode(Node expression)
            {
                _expression = expression;
            }
        }
        abstract class BinaryNode : Node
        {
            private readonly Node _leftExpression;
            private readonly Node _rightExpression;
            public Node LeftExpression
            {
                get { return _leftExpression; }
            }
            public Node RightExpression
            {
                get { return _rightExpression; }
            }
            protected BinaryNode(Node leftExpression, Node rightExpression)
            {
                _leftExpression = leftExpression;
                _rightExpression = rightExpression;
            }
        }
        class AndNode : BinaryNode
        {
            public AndNode(Node leftExpression, Node rightExpression)
                : base(leftExpression, rightExpression)
            {
            }
            public override bool Eval(IPrincipal principal)
            {
                return LeftExpression.Eval(principal) && RightExpression.Eval(principal);
            }
        }
        class OrNode : BinaryNode
        {
            public OrNode(Node leftExpression, Node rightExpression)
                : base(leftExpression, rightExpression)
            {
            }
            public override bool Eval(IPrincipal principal)
            {
                return LeftExpression.Eval(principal) || RightExpression.Eval(principal);
            }
        }
        class XorNode : BinaryNode
        {
            public XorNode(Node leftExpression, Node rightExpression)
                : base(leftExpression, rightExpression)
            {
            }
            public override bool Eval(IPrincipal principal)
            {
                return LeftExpression.Eval(principal) ^ RightExpression.Eval(principal);
            }
        }
        class NotNode : UnaryNode
        {
            public NotNode(Node expression)
                : base(expression)
            {
            }
            public override bool Eval(IPrincipal principal)
            {
                return !Expression.Eval(principal);
            }
        }
        class RoleNode : Node
        {
            private readonly string _roleName;
            public string RoleName
            {
                get { return _roleName; }
            }
            public RoleNode(string roleName)
            {
                _roleName = roleName;
            }
            public override bool Eval(IPrincipal principal)
            {
                return principal.IsInRole(RoleName);
            }
        }
        private Node _expression;
        void Parse(string text)
        {
            if (text == null) throw new ArgumentNullException("text");
            var delimiters = new[] { TokenSeparator, TokenAnd, TokenOr, TokenXor, TokenNot, TokenParentheseOpen, TokenParentheseClose };
            List<string> tokens = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == TokenSeparator)
                    continue;
                if (delimiters.Contains(c))
                {
                    if (sb.Length > 0)
                    {
                        tokens.Add(sb.ToString());
                        sb.Clear();
                    }
                    tokens.Add(c.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    sb.Append(c);
                }
            }
            if (sb.Length > 0)
            {
                tokens.Add(sb.ToString());
            }
            _expression = Parse(tokens.ToArray());
        }
        Node Parse(string[] tokens)
        {
            int index = 0;
            return ParseExp(tokens, ref index);
        }
        Node ParseExp(string[] tokens, ref int index)
        {
            Node leftExp = ParseSubExp(tokens, ref index);
            if (index > tokens.Length)
                return leftExp;
            string token = tokens[index];
            if (token == "&")
            {
                index++;
                Node rightExp = ParseSubExp(tokens, ref index);
                return new AndNode(leftExp, rightExp);
            }
            else if (token == "|")
            {
                index++;
                Node rightExp = ParseSubExp(tokens, ref index);
                return new OrNode(leftExp, rightExp);
            }
            else if (token == "^")
            {
                index++;
                Node rightExp = ParseSubExp(tokens, ref index);
                return new XorNode(leftExp, rightExp);
            }
            else
            {
                throw new Exception("Expected '&' or '|' or EOF");
            }
        }
        Node ParseSubExp(string[] tokens, ref  int index)
        {
            string token = tokens[index];
            if (token == "(")
            {
                index++;
                Node node = ParseExp(tokens, ref index);
                if (tokens[index] != ")")
                    throw new Exception("Expected ')'");
                index++; // Skip ')'
                return node;
            }
            else if (token == "!")
            {
                index++;
                Node node = ParseExp(tokens, ref index);
                return new NotNode(node);
            }
            else
            {
                index++;
                return new RoleNode(token);
            }
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
            if (_expression == null)
            {
                Parse(Roles);
            }
            if (_expression != null)
            {
                return _expression.Eval(user);
            }
            return true;
        }
    }
