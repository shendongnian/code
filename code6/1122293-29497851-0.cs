    public class YourContext : DbContext
    {
      private static readonly List<PropertyInfo> EmptyPropsList = new List<PropertyInfo>();
      private static readonly Hashtable PropsCache = new Hashtable(); // Spec promises safe for single-reader, multiple writer.
                                                                      // Spec for Dictionary makes no such promise, and while
                                                                      // it should be okay in this case, play it safe.
      private static List<PropertyInfo> GetDateProperties(Type type)
      {
        List<PropertyInfo> list = new List<PropertyInfo>();
        foreach(PropertyInfo prop in type.GetProperties())
        {
          Type valType = prop.PropertyType;
          if(valType == typeof(DateTime) || valType == typeof(DateTime?))
            list.Add(prop);
        }
        if(list.Count == 0)
          return EmptyPropsList; // Don't waste memory on lots of empty lists.
        list.TrimExcess();
        return list;
      }
      private static void FixDates(object sender, ObjectMaterializedEventArgs evArg)
      {
        object entity = evArg.Entity;
        if(entity != null)
        {
          Type eType = entity.GetType();
          List<PropertyInfo> rules = (List<PropertyInfo>)PropsCache[eType];
          if(rules == null)
            lock(PropsCache)
              PropsCache[eType] = rules = GetPropertyRules(eType); // Don't bother double-checking. Over-write is safe.
          foreach(var rule in rules)
          {
            var info = rule.PropertyInfo;
            object curVal = info.GetValue(entity);
            if(curVal != null)
              info.SetValue(entity, DateTime.SpecifyKind((DateTime)curVal, rule.Kind));
          }
        }
      }
      public YourContext()
      {
        ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += FixDates;
    	/* rest of constructor logic here */
      }
      /* rest of context class here */
    }
