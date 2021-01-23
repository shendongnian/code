        public static bool TryGetName(Expression<Action> expr, out string memberName)
        {
            memberName = null;
            var body = expr.Body as MethodCallExpression;
            if (body == null)
                return false;
            memberName = body.Method.Name;
            return true;
        }
