    Expression<Func<Environment,bool>> expr = _ => _.Colour == MyColourEnum.Red;
    BinaryExpression binaryExpression = (BinaryExpression)expr.Body;
    var convert = (UnaryExpression)binaryExpression.Left;
    var propertyExpression = (MemberExpression)convert.Operand;
    var property = (PropertyInfo)propertyExpression.Member;
    Enum enumValue = (Enum)Enum.ToObject(property.PropertyType, ((ConstantExpression)binaryExpression.Right).Value); //
    FieldInfo fi = property.PropertyType.GetField(enumValue.ToString());
    var renderAs = fi.GetCustomAttribute<RenderAsAttribute>();
    if (renderAs != null)
    {
        String color = renderAs.Color;
        Console.WriteLine("{0}.{1} == {2}", property.DeclaringType.Name, property.Name, color);
    }
