    class Test : IConditionalPropertySource<Test>
    {
        // Your properties here:
        public string SomeSetting { get; set; }
        // This is the equality comparer used for the dictionary below
        private class MemberNameComparer :
            IEqualityComparer<Expression<Func<Test, object>>>
        {
            public bool Equals(
                Expression<Func<Test, object>> lhs, 
                Expression<Func<Test, object>> rhs)
            {
                return GetMemberName(lhs).Equals(GetMemberName(rhs));
            }
            
            public int GetHashCode(Expression<Func<Test, object>> expr)
            {
                return GetMemberName(expr).GetHashCode();
            }
            
            private string GetMemberName(Expression<Func<Test, object>> expr)
            {
                return ((MemberExpression)expr.Body).Member.Name;
            }
        }
        
        // A dictionary that maps member access expressions to boolean functions
        private readonly IDictionary<Expression<Func<Test, object>>, Func<bool>> 
            conditions = new Dictionary<Expression<Func<Test, object>>, Func<bool>>
            (new MemberNameComparer())
            {
                // The "SomeSetting" property is only visible on Wednesdays
                { 
                    self => self.SomeSetting, 
                    () => DateTime.Now.DayOfWeek == DayOfWeek.Wednesday
                }
            };
       
        
        // This implementation is now trivial
        public bool IsPropertyApplicable(Expression<Func<Test, object>> expr)
        {
            return conditions[expr]();
        }
    }
