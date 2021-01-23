    public static IQueryable<Car> FilterCars(this IQueryable<Car> cars, IEnumerable<SearchCar> searchCars)
            {
                var parameter = Expression.Parameter(typeof (Car), "m");
    
                var idExpression = Expression.Property(parameter, "Id");
                var modelExpression = Expression.Property(parameter, "Model");
    
                Expression body = null;
                foreach (var search in searchCars)
                {
                    var idConstant = Expression.Constant(search.Id);
                    var modelConstant = Expression.Constant(search.Model);
    
                    Expression innerExpression = Expression.AndAlso(Expression.Equal(idExpression, idConstant), Expression.Equal(modelExpression, modelConstant));
                    body = body == null
                        ? innerExpression
                        : Expression.OrElse(body, innerExpression);
                }
                var lambda = Expression.Lambda<Func<Car, bool>>(body, new[] {parameter});
                return cars.Where(lambda);
            }
