    public static class RaisePropertyChangedExtensions
    {
        public static void RaisePropertyChanged<T>(
            this IRaisePropertyChanged raisePropertyChangedImpl,
            Expression<Func<T>> expr)
        {
            var memberExprBody = expr.Body as MemberExpression;
            string property = memberExprBody.Member.Name;
            raisePropertyChangedImpl.RaisePropertyChanged(property);
        }
    }
