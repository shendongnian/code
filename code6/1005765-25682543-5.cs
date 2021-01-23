    public static class ClientObjectExtensions
    {
        /// <summary>
        /// Determines whether Client Object property is loaded
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clientObject"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsPropertyAvailableOrInstantiated<T>(this T clientObject, Expression<Func<T, object>> property)
            where T : ClientObject
        {
            var expression = (MemberExpression)property.Body;
            var propName = expression.Member.Name;
            var isCollection = typeof(ClientObjectCollection).IsAssignableFrom(property.Body.Type);
            return isCollection ? clientObject.IsObjectPropertyInstantiated(propName) : clientObject.IsPropertyAvailable(propName);
        }
    }
