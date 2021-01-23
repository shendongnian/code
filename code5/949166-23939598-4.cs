            protected void RaisePropertyChanged<T>(System.Linq.Expressions.Expression<Func<T>> lambda)
            {
                if (lambda == null) throw new ArgumentNullException("lambda");
             
                var memberExpression = lambda.Body as MemberExpression;
                if (memberExpression == null) throw new ArgumentException("Invalid lambda expression.","lambda");
                
                var property = memberExpression.Member as PropertyInfo;
                if (property == null) throw new ArgumentException("Invalid lambda expression. Expression must be a property.", "lambda");
    
                // check if the property is not static
                var getMethod = property.GetGetMethod(true);
                if (getMethod.IsStatic) throw new ArgumentException("Invalid lambda expression. Property cannot be static.", "propertyExpression");
    
                string propertyName = memberExpression.Member.Name;
                OnPropertyChanged(propertyName);
            }
