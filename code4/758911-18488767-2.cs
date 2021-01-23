    public class Member
    {
        public string ScreenName { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public static Expression<Func<Member, string>> GetRealNameExpression()
        {
            return m => (m.Name + " " + m.LastName).TrimEnd();
        }
        public static Expression<Func<Member, string>> GetDisplayNameExpression()
        {
            var isNullOrEmpty = typeof(string).GetMethod("IsNullOrEmpty", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string) }, null);
            var e0 = GetRealNameExpression();
            var par1 = e0.Parameters[0];
            // Done in this way, refactoring will correctly rename m.ScreenName
            // We could have used a similar trick for string.IsNullOrEmpty,
            // but it would have been useless, because its name and signature won't
            // ever change.
            Expression<Func<Member, string>> e1 = m => m.ScreenName;
            var screenName = (MemberExpression)e1.Body;
            var prop = Expression.Property(par1, (PropertyInfo)screenName.Member);
            var condition = Expression.Condition(Expression.Call(null, isNullOrEmpty, prop), e0.Body, prop);
            var combinedExpression = Expression.Lambda<Func<Member, string>>(condition, par1);
            return combinedExpression;
        }
        private static readonly Func<Member, string> GetDisplayNameExpressionCompiled = GetDisplayNameExpression().Compile();
        private static readonly Func<Member, string> GetRealNameExpressionCompiled = GetRealNameExpression().Compile();
        public string DisplayName
        {
            get
            {
                return GetDisplayNameExpressionCompiled(this);
            }
        }
        public string RealName
        {
            get
            {
                return GetRealNameExpressionCompiled(this);
            }
        }
        public static Expression<Func<Member, bool>> FilterMemberByDisplayNameExpression(string displayName)
        {
            var e0 = GetDisplayNameExpression();
            var par1 = e0.Parameters[0];
            var combinedExpression = Expression.Lambda<Func<Member, bool>>(
                Expression.Equal(e0.Body, Expression.Constant(displayName)), par1);
            return combinedExpression;
        }
