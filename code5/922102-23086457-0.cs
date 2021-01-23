    foreach (var subClass in subClasses)
    {
       var instance = (EntityBase)Activator.CreateInstance(subClass);
       var value = subClass.GetProperty("Api", BindingFlags.Instance | BindingFlags.Public).GetValue(instance, null); 
    }
