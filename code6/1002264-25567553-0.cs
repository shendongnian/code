    public class MyRuleBuilder<T, U>
    {
        public Dictionary<string, object> Rules = new Dictionary<string,object>();
    
        public MyRuleBuilder<T, U> If(Expression<Func<T, U>> exp, U value)
        {
            Rules.Add(exp.GetMember().Name, value);
    
            return this;
        }
    }
