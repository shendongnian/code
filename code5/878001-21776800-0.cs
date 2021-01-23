    Expression<Func<Customer, bool>> filter1 = c => c.Active;
    Expression<Func<Customer, bool>> filter2 = c => c.Visible;
    var parameter = Expression.Parameter(typeof(Customer), "x");
            
    var filter = Expression.Lambda<Func<Customer, bool>>(
                    Expression.And(
                        Expression.Invoke(filter1,parameter),
                        Expression.Invoke(filter2,parameter)
                    ),parameter
                );
