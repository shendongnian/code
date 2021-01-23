    public void AddMapForPolymorphic<TBase>(Expression<Func<IEnumerable<TBase>, IEnumerable>> expr)
        {
            AddMap(expr);
            var children = Modules.Modules.Instance.GetModules()
                .SelectMany(a => AssemblyHelper.GetClassesWithBaseType<TBase>(a.GetType().Assembly)
                );
            var addMapGeneric = GetType()
                .GetMethod("AddMap", BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var child in children)
            {
                if (!child.HasAttribute<IgnorePolymorpAttribute>())
                {
                    var genericEnumerable = typeof(IEnumerable<>)
                        .MakeGenericType(child);
                    var delegateType = typeof(Func<,>)
                        .MakeGenericType(genericEnumerable, typeof(IEnumerable));
                    var lambdaExpression = Expression.Lambda(delegateType, expr.Body, Expression
                        .Parameter(genericEnumerable, expr.Parameters[0].Name));
                    addMapGeneric
                        .MakeGenericMethod(child).Invoke(this, new[] { lambdaExpression });
                }
            }
        }
