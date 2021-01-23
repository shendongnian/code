    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        abstract class Node
        {
            public abstract bool Eval(IPrincipal principal);
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
            /*
                * Exp -> SubExp '&' SubExp
                * Exp -> SubExp '|' SubExp
                * SubExp -> '(' Exp ')'
                * SubExp -> RoleName
                * RoleName -> [a-z]
                */
            var delimiters = new[] { ' ', '&', '|', '(', ')' };
            List<string> tokens = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == ' ')
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
