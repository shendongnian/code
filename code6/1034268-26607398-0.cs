    [GridAction(EnableCustomBinding = true)]
    public ViewResult GetRecords(GridCommand command)
    {
        using (var context = _contextFactory())
        {
            var records = context.Set<Records>();
            if (command.FilterDescriptors.Any())    //RequestNumber
            {                    
                var filter = command.FilterDescriptors.GetFilter<ChangeRecord>();
                records = records.Where(filter);
            }
            return View(new GridModel(records.ToArray()));
        }
    }
    public static class GridCommandExtensions
    {
        public static Expression<Func<TGridModel, bool>> GetFilter<TGridModel>(this IList<IFilterDescriptor> filterDescriptors)
        {
            var filters = filterDescriptors.SelectMany(GetAllFilterDescriptors).ToArray();
            var parameter = Expression.Parameter(typeof(TGridModel), "c");
            if (filters.Length == 1)
                return Expression.Lambda<Func<TGridModel, bool>>(GetExpression(parameter, filters[0]), parameter);
            Expression exp = null;
            for (int index = 0; index < filters.Length; index += 2)   // условие И
            {
                var filter1 = filters[index];
                if (index == filters.Length - 1)
                {
                    exp = Expression.AndAlso(exp, GetExpression(parameter, filter1));
                    break;
                }
                var filter2 = filters[index + 1];
                var left = GetExpression(parameter, filter1);
                var right = GetExpression(parameter, filter2);
                exp = exp == null
                    ? Expression.AndAlso(left, right)
                    : Expression.AndAlso(exp, Expression.AndAlso(left, right));
            }
            return Expression.Lambda<Func<TGridModel, bool>>(exp, parameter);
        }
        private static Expression GetExpression(ParameterExpression parameter, FilterDescriptor filter)
        {
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            var endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            var property = filter.Member.Contains(".") ?
                filter.Member.Split('.').Aggregate((Expression)parameter, Expression.Property)  // (x => x.Property.FieldName)
                : Expression.Property(parameter, filter.Member);                                // (x => x.FieldName)
            var constant = Expression.Constant(filter.Value);               // значение для выражения
            switch (filter.Operator)
            {
                case FilterOperator.IsEqualTo:
                    return Expression.Equal(property, constant);
                case FilterOperator.IsNotEqualTo:
                    return Expression.NotEqual(property, constant);
                case FilterOperator.Contains:
                    return Expression.Call(property, containsMethod, constant);
                case FilterOperator.StartsWith:
                    return Expression.Call(property, startsWithMethod, constant);
                case FilterOperator.EndsWith:
                    return Expression.Call(property, endsWithMethod, constant);
                case FilterOperator.IsGreaterThan:
                    return Expression.GreaterThan(property, constant);
                case FilterOperator.IsGreaterThanOrEqualTo:
                    return Expression.GreaterThanOrEqual(property, constant);
                case FilterOperator.IsLessThan:
                    return Expression.LessThan(property, constant);
                case FilterOperator.IsLessThanOrEqualTo:
                    return Expression.LessThanOrEqual(property, constant);
                default:
                    throw new InvalidOperationException(string.Format("Неподдерживаемая операция {0} для колонки {1}", filter.Operator, filter.Member));
            }
        }
        public static IEnumerable<FilterDescriptor> GetAllFilterDescriptors(this IFilterDescriptor descriptor)
        {
            var filterDescriptor = descriptor as FilterDescriptor;
            if (filterDescriptor != null)
            {
                yield return filterDescriptor;
                yield break;
            }
            var compositeFilterDescriptor = descriptor as CompositeFilterDescriptor;
            if (compositeFilterDescriptor != null)
            {
                if (compositeFilterDescriptor.LogicalOperator == FilterCompositionLogicalOperator.Or)
                    throw new ArgumentOutOfRangeException("descriptor", "В фильтрах не поддерживается OR");
                foreach (var childDescriptor in compositeFilterDescriptor.FilterDescriptors.SelectMany(GetAllFilterDescriptors))
                    yield return childDescriptor;
            }
        }
     }
