        /// <summary>
        /// Wraps up a each of a query's objects in a ContactPointExt&lt;T&gt; object, providing the default contact point of each type.
        /// The original query object is accessed via the "Instance" property on each result.
        /// Assumes that the query object type has a property called ContactPoints - if different, supply the property name as the first argument.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="contactPointsPropertyName"></param>
        /// <returns></returns>
        public static IQueryable<ContactPointExt<T>> WithContactPointProcessing<T>(this IQueryable<T> query, string contactPointsPropertyName = "ContactPoints") where T : class
        {
            var siteParam = Expression.Parameter(typeof(T), "s");
            var cpeParam = Expression.Parameter(typeof(ContactPointEntity), "cpe");
            var selector = ContactPointHelpers.GetContactPoints<T>(siteParam, cpeParam, contactPointsPropertyName);
            return query.Select(selector);
        }
