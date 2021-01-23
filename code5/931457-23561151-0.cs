    public InheritedClass(SuperClass superClassInstance)
    {
     foreach(var currentItem in superClassInstance.GetType().GetProperties())
      {
        GetType().GetProperty(currentItem.Name).SetValue(this,currentItem.GetValue(superClassInstance,null),null);
      }
    }
