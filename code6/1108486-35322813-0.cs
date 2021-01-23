    var keyCompare = key.Properties[0].Name;
            // TODO: Build the real LINQ Expression
            // set.Where(x => x.Id == keyValues[0]);
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var query = set.Where((Expression<Func<TEntity, bool>>)
                Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, keyCompare),
                        //Expression.Property(parameter, "Id"),
                        Expression.Constant(keyValues[0])),
                    parameter));
            // Look in the database
            return query.FirstOrDefault();
        }
