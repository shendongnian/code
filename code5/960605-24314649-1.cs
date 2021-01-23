    /// <summary>
    /// Gets the first entity that matches the query expression.  Null is returned if none are found.
    /// </summary>
    /// <typeparam name="T">The Entity Type.</typeparam>
    /// <param name="service">The service.</param>
    /// <param name="qe">The query expression.</param>
    /// <returns></returns>
    public static T GetFirstOrDefault<T>(this IOrganizationService service, QueryExpression qe) where T : Entity
    {
        qe.First();
        return service.RetrieveMultiple(qe).ToEntityList<T>().FirstOrDefault();
    }
    /// <summary>
    /// Converts the entity collection into a list, casting each entity.
    /// </summary>
    /// <typeparam name="T">The type of Entity</typeparam>
    /// <param name="col">The collection to convert</param>
    /// <returns></returns>
    public static List<T> ToEntityList<T>(this EntityCollection col) where T : Entity
    {
        return col.Entities.Select(e => e.ToEntity<T>()).ToList();
    }
