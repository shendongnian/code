    void ShowPropertyName<T1>(T1 p, params Expression<Func<T1, object>>[] properties)
        {
            foreach (var e in properties)
            {
                var f = e.Compile();
                MemberExpression memberExpression;
                if (e.Body is UnaryExpression)
                {
                    var unaryExpression = e.Body as UnaryExpression;
                    memberExpression = unaryExpression.Operand as MemberExpression;
                }
                else if(e.Body is MemberExpression)
                {
                    memberExpression = e.Body as MemberExpression;
                }
                else
                {
                    Console.WriteLine("Unsupported Body expression of type {0}", e.Body.GetType());
                    return;
                }
                var memberInfo = memberExpression.Member;
                Console.WriteLine("{0}: {1}", memberInfo.Name, f(p));
            }
        }
