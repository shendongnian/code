    var selectorString = "Employee.Section.SectionName";
    var properties = selectorString.Split(".");
    var property = Expression.Property(parameter, properties[0]);
    
    //You can add like this 
    property = properties.Skip(1).Aggregate(property, (current, propertyName) => Expression.Property(current, propertyName));
    //or you use a shorter version by passing as a method group
    property = properties.Skip(1).Aggregate(property, Expression.Property);
    var expression = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(TEntity), property.Type), property, parameter);
