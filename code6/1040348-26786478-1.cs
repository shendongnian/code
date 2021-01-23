    public class JoinVisitor : ExpressionVisitor
    {
        private static readonly MemberInfo[] _joinMethods;
        private ICollection<Type> Types = new HashSet<Type>();
        static JoinVisitor()
        {
            _joinMethods =
                typeof (Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == "Join").ToArray();
        }
        // make use of GetJoinTypes to create class
        private JoinVisitor()
        {
            
        }
        public static IEnumerable<Type> GetJoinTypes(System.Linq.Expressions.Expression expression)
        {
            var joinVisitor = new JoinVisitor();
            joinVisitor.Visit(expression);
            return joinVisitor.Types;
        }
        protected override System.Linq.Expressions.Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsGenericMethod && _joinMethods.Contains(node.Method.GetGenericMethodDefinition()))
            {
                var args = node.Method.GetGenericArguments();
                Types.Add(args[0]);
                Types.Add(args[1]);
            }
            return base.VisitMethodCall(node);
        }
    }
