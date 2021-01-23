        string PropertyName<T>(Expression<Func<T>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }
            return string.Join(".", GetPropertyNames(body).Reverse());
        }
        private IEnumerable<string> GetPropertyNames(MemberExpression body)
        {
            while (body != null)
            {
                yield return body.Member.Name;
                var inner = body.Expression;
                switch (inner.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        body = inner as MemberExpression;
                        break;
                    default:
                        body = null;
                        break;
                }
            }
        }
