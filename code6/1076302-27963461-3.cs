    public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
    {
        var self = Expression.Convert(Expression, LimitType);
        Expression expression;
        var propertyName = binder.Name;
        var args = new Expression[1];
    
        args[0] = Expression.Constant(propertyName);
        expression = Expression.Call(self, typeof(MyDynViewModel).GetMethod("GetDynamicObject", BindingFlags.Public | BindingFlags.Instance), args);
    
        expression = "if GetDynamicObject returned false, means we found nothing.
              then we should return binder.FallbackGetMember(this, e)";
    
        var getMember = new DynamicMetaObject(expression, BindingRestrictions.GetTypeRestriction(Expression, LimitType));
        return getMember;
    }
