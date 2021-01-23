    public class CSV
    {
        public static StringBuilder ToCSV(IEnumerable list)
        {
            Func<object, object[]> toArray = null;
            var sb = new StringBuilder();
            // Need to initialize the loop and on the first one grab the properties to setup the columns
            foreach (var item in list)
            {
                if (toArray == null)
                {
                    toArray = ItemToArray(item.GetType());
                }
                sb.AppendLine(String.Join(",", toArray(item)));
            }
            return sb;
        }
        private static Func<object, object[]> ItemToArray(Type type)
        {
            var props = type.GetProperties().Where(p => p.CanRead);
            var arrayBody = new List<Expression>();
            // Create a parameter to take the item enumeration
            var sourceObject = Expression.Parameter(typeof (object), "source");
            // Convert it to the type that is passed in
            var sourceParam = Expression.Convert(sourceObject, type);
            foreach (var prop in props)
            {
                var propType = prop.PropertyType;
                if (IsValueProperty(propType))
                {
                    // get the value of the property
                    Expression currentProp = Expression.Property(sourceParam, prop);
                    // Need to box to an object if value type
                    if (propType.IsValueType)
                    {
                        currentProp = Expression.TypeAs(currentProp, typeof (object));
                    }
                    // Add to the collection of expressions so we can build the array off of this collection
                    arrayBody.Add(currentProp);
                }
            }
            // Create an array based on the properties
            var arrayExp = Expression.NewArrayInit(typeof (object), arrayBody);
            // set a default return value of null if couldn't match
            var defaultValue = Expression.NewArrayInit(typeof (object), Expression.Constant(null));
            //Set up so the lambda can have a return value
            var returnTarget = Expression.Label(typeof (object[]));
            var returnExpress = Expression.Return(returnTarget, arrayExp, typeof (object[]));
            var returnLabel = Expression.Label(returnTarget, defaultValue);
            //Create the method
            var code = Expression.Block(arrayExp, returnExpress, returnLabel);
            return Expression.Lambda<Func<object, object[]>>(code, sourceObject).Compile();
        }
        private static bool IsValueProperty(Type propertyType)
        {
            var propType = propertyType;
            if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                propType = new NullableConverter(propType).UnderlyingType;
            }
            return propType.IsValueType || propType == typeof (string);
        }
    }
