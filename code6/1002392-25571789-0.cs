    public class TEntity : BaseEntity
    {
    }
    var references = o.GetType()
        .GetProperties()
        .Where(p => p.PropertyType.BaseType == typeof(BaseEntity))
        .Select(p => p.GetValue(o))
        .Where(t => t != null)
        .ToArray();
    foreach (var reference in references)
    {
        db.Entry(reference).State = EntityState.Unchanged;
    }
    db.Set<TEntity>().Add(o);
    db.SaveChanges();
