        /// <summary>
        /// Converts list of items into typed list of item of new type
        /// </summary>
        /// <example><code>
        /// Consider source to be List<object>, newItemType is typeof(string), so resulting list wil have type List<string>
        /// </code></example>
        /// <param name="newItemType">New item type</param>
        /// <param name="source">List of objects</param>
        /// <returns>Typed List object</returns>
        public static IList ConvertList(Type newItemType, IList source)
        {
            var listType = typeof(List<>);
            Type[] typeArgs = { newItemType };
            var genericListType = listType.MakeGenericType(typeArgs);
            var typedList = (IList)Activator.CreateInstance(genericListType);
            foreach (var item in source)
            {
                typedList.Add(item);
            }
            return typedList;
        }
