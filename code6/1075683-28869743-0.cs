		public static Func<object, object> GenerateGetterFunc(this PropertyInfo pi)
        {
            //p=> ((pi.DeclaringType)p).<pi>
            var expParamPo = Expression.Parameter(typeof(object), "p");
            var expParamPc = Expression.Convert(expParamPo,pi.DeclaringType);
            var expMma = Expression.MakeMemberAccess(
                    expParamPc
                    , pi
                );
            
            var expMmac = Expression.Convert(expMma, typeof(object));
            var exp = Expression.Lambda<Func<object, object>>(expMmac, expParamPo);
            return exp.Compile();
        }
        public static Action<object, object> GenerateSetterAction(this PropertyInfo pi)
        {
            //p=> ((pi.DeclaringType)p).<pi>=(pi.PropertyType)v
            var expParamPo = Expression.Parameter(typeof(object), "p");
            var expParamPc = Expression.Convert(expParamPo,pi.DeclaringType);
            
            var expParamV = Expression.Parameter(typeof(object), "v");
            var expParamVc = Expression.Convert(expParamV, pi.PropertyType);
            var expMma = Expression.Call(
                    expParamPc
                    , pi.GetSetMethod()
                    , expParamVc
                );
            var exp = Expression.Lambda<Action<object, object>>(expMma, expParamPo, expParamV);
            return exp.Compile();
        }
