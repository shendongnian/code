    public static IEnumerable<string> GetMemberNames(object target, bool dynamicOnly = false)
    {
        var tList = new List<string>();
        if (!dynamicOnly)
        {
           tList.AddRange(target.GetType().GetProperties().Select(it => it.Name));
        }
        var tTarget = target as IDynamicMetaObjectProvider;
        if (tTarget !=null)
        {
            tList.AddRange(tTarget.GetMetaObject(Expression.Constant(tTarget)).GetDynamicMemberNames());
        }else
        {
            if (ComObjectType != null && ComObjectType.IsInstanceOfType(target) && ComBinder.IsAvailable)
            {
                tList.AddRange(ComBinder.GetDynamicDataMemberNames(target));
            }
        }
        return tList;
    } 
