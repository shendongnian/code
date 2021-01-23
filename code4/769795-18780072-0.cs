    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    public Action<TProperty> GetSetterAction(TSource target,
         Expression<Func<TSource, TProperty>> propertyExpression)
    {
        var memberExpression = propertyExpression.Body as MemberExpression;
        if (memberExpression == null)
        {
            throw new ArgumentException(@"propertyExpression must express a single
                member of a type.", "propertyExpression");
        }
        var propertyInfo = memberExpression.Member as PropertyExpression;
        if (propertyInfo == null)
        {
            throw new ArgumentException(@"propertyExpression must express a single
               property of a type.", "propertyExpression");
        }
        var setMethodInfo = propertyInfo.GetSetMethod();
        if (setMethodInfo == null)
        {
            throw new ArgumentException(@"propertyExpression must express a single
                writeable property of a type.", "propertyExpression");
        }
        var setMethodDelegate = setMethodInfo.CreateDelegate(
            typeof(Action<TProperty>), target);
        return (Action<TProperty>)(object)setMethodDelegate;
    }
