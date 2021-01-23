    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    public class PropHandle<TOwner, TProperty>
    {
        private TOwner owner;
        private PropertyInfo propertyInfo;
        public PropHandle(TOwner owner, Expression<Func<TOwner, TProperty>> propertyExpression)
        {
            this.owner = owner;
            var memberExpression = (MemberExpression)propertyExpression.Body;
            this.propertyInfo = (PropertyInfo)memberExpression.Member;
        }
        public TProperty Get()
        {
            return (TProperty)this.propertyInfo.GetValue(this.owner, null);
        }
        public void Set(TProperty value)
        {
            this.propertyInfo.SetValue(this.owner, value, null);
        }
    }
