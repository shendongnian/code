    if (property.PropertyType.IsGenericType &&
     property.PropertyType.GetGenericTypeDefinition()
       == typeof(ICollection<>))
    {
      Type itemType = property.PropertyType.GetGenericArguments()[0];
      ICollection<Person> objectList =GetObjectList().Cast<ICollection<Person>>();
      property.SetValue(item, objectList);
    }
