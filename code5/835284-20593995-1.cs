            var startPar = Expression.Parameter(typeof (T), "start");
            var endPar = Expression.Parameter(typeof (T), "end");
            var amountPar = Expression.Parameter(typeof (float), "amount");
            foreach (var fieldInfo in fields)
            {
                MethodInfo mi;
                if (fieldInfo.FieldType.IsAssignableFrom(typeof (float)))
                {
                    mi = typeof (Program).GetMethod("LerpF");
                }
                else
                {
                    mi = typeof (Program).GetMethod("Lerp").MakeGenericMethod(fieldInfo.FieldType);
                }
                var makeMemberAccess = Expression.Call(mi, Expression.MakeMemberAccess(startPar, fieldInfo), Expression.MakeMemberAccess(endPar, fieldInfo), amountPar);
                binds.Add(Expression.Bind(fieldInfo, makeMemberAccess));
            }
            
            var memberInit = Expression.MemberInit(Expression.New(type), binds);
            var expression = Expression.Lambda<Func<T, T, float, T>>(memberInit, startPar, endPar, amountPar);
            Func<T, T, float, T> resultFunc = expression.Compile();
            // can cache resultFunc
            var result = resultFunc(start, end, amount);
