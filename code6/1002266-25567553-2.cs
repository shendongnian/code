    public class MyRuleBuilder<T>
    {
        public Dictionary<string, object> Rules = new Dictionary<string, object>();
    
        public MyRuleBuilder<T> If<U>(Expression<Func<T, U>> exp, U value)
        {
            Rules.Add(exp.GetMember().Name, value);
    
            return this;
        }
    }
