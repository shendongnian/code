public static bool IsPropertyAvailableOrInstantiated<T>(this T clientObject, Expression<Func<T, object>> property)
    where T : ClientObject
{
    var expression = (MemberExpression)property.Body;
    var propName = expression.Member.Name;
    var isObject = typeof(ClientObject).IsAssignableFrom(property.Body.Type); // test with ClientObject instead of ClientObjectList
    return isObject ? clientObject.IsObjectPropertyInstantiated(propName) : clientObject.IsPropertyAvailable(propName);
}
`
