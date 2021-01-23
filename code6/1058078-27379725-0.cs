    private IList<TEntity> Condition<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, TProperty propertyValue)
            where TEntity :class 
        {
            PropertyInfo property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;
            ParameterExpression typeParameter = Expression.Parameter(typeof(TEntity));
            MemberExpression propertyExpression = Expression.Property(typeParameter, property);
            using (Minorlex_MPIPSEntities entities = new Minorlex_MPIPSEntities())
            {
                BinaryExpression criteriaExpression = 
                    Expression.Equal(propertyExpression, Expression.Constant(propertyValue));
                Expression<Func<TEntity, bool>> condition = 
                    Expression.Lambda<Func<TEntity, bool>>(criteriaExpression, typeParameter);
                IEnumerable<TEntity> query = entities.Set<TEntity>().Where(condition);
                return query.ToList();
            }
        }
