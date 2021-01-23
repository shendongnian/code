             public override DynamicMetaObject BindGetMember(GetMemberBinder aBinder)
        {
            var aMetaObject = this;
            var aIsMethod = aMetaObject.IsMethod(aBinder.Name, aBinder.IgnoreCase);
            if (aIsMethod)
            {
                var aRestrictions = BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType);
                var aThisExpression = Expression.Convert(this.Expression, this.LimitType);
                var aMethodInfo = typeof(CDynamicObjectScriptAdapter).GetMethod(CDynamicObjectScriptAdapter.GetDelegate_MethodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var aParameters = new Expression[] { Expression.Constant(aBinder) };
                var aCallExpression = Expression.Call(aThisExpression, aMethodInfo, aParameters);
                var aResult = new DynamicMetaObject(aCallExpression, aRestrictions);
                return aResult;
            }
            else
            {
                var aRestrictions = BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType);
                var aThisExpression = Expression.Convert(this.Expression, this.LimitType);
                var aMethodInfo = typeof(CDynamicObjectScriptAdapter).GetMethod(CDynamicObjectScriptAdapter.GetValue_MethodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var aParameters = new Expression[] { Expression.Constant(aBinder) };
                var aCallExpression = Expression.Call(aThisExpression, aMethodInfo, aParameters);
                var aResult = new DynamicMetaObject(aCallExpression, aRestrictions);
                return aResult;
            }
        }
        internal const string GetDelegate_MethodName = "GetDelegate";
        internal object GetDelegate(GetMemberBinder aBinder)
        {
            var aScriptAdapter = this;
            var aAdaptedObject = aScriptAdapter.AdaptedObject;
            var aClassInfo = aAdaptedObject.ClassInfo;
            var aIgnoreCase = aBinder.IgnoreCase;
            var aCaseSensitive = !aIgnoreCase;
            var aMethodInfoDic = aClassInfo.GetScriptMethodInfoDic(aCaseSensitive);
            var aName = aBinder.Name;
            var aScriptMethodInfo = aMethodInfoDic[aName];
            var aMethodInfo = aScriptMethodInfo.MethodInfo;
            var aDelegateType = aScriptMethodInfo.ScriptMethodAttribute.DelegateType;
            var aDelegate = aMethodInfo.CreateDelegate(aDelegateType, aAdaptedObject);
            return aDelegate;
        }
