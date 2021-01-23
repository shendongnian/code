    class C<T>
    {        
    
        public T First<TProperty1, TProperty2>(
            Expression<Func<T, TProperty1>> orderBy = null, 
            Expression<Func<T, TProperty2>> groupBy = null)
        {
            string orderByName = string.Empty;
            string groupByName = string.Empty;
            if (orderBy != null)
            {
                System.Reflection.PropertyInfo orderByInfo = (System.Reflection.PropertyInfo)((MemberExpression)orderBy.Body).Member;
                orderByName = orderByInfo.Name;
            }
    
            if (groupBy != null)
            {
                System.Reflection.PropertyInfo groupByInfo = (System.Reflection.PropertyInfo)((MemberExpression)groupBy.Body).Member;
                groupByName = groupByInfo.Name;
            }
            ....
        }
    }
