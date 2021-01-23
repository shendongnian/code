    public class SearchEngine<T>
    {
        // Removed other parameters to make it simple
        public IEnumerable<T> Search<K>(Expression<Func<T, K>> orderBy)
        {
            var name = GetMemberName(orderBy.Body);
            throw new NotImplementedException();
        }
        static string GetMemberName(Expression expression)
		{
			string memberName = null;
			var memberExpression = expression as MemberExpression;
			if (memberExpression != null)
				memberName = memberExpression.Member.Name;
			var unaryExpression = expression as UnaryExpression;
			if (unaryExpression != null)
				memberName = ((MemberExpression) unaryExpression.Operand).Member.Name;
			var methodCallExpression = expression as MethodCallExpression;
			if (methodCallExpression != null)
				memberName = methodCallExpression.Method.Name;
			Contract.Assume(memberName != null);
			return memberName;
		}
    }
    
