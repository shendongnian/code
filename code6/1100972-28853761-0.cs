    public static object operator ==(Class1 @object, Type type)
    {
      return (object) (bool) (@object.GetType() == type ? 1 : 0);
    }
    public static object operator !=(Class1 @object, Type type)
    {
      return (object) (bool) (@object.GetType() != type ? 1 : 0);
    }
    public static object operator ==(Class1 @object, object o)
    {
      return (object) (bool) (@object.GetType() == o ? 1 : 0);
    }
    public static object operator !=(Class1 @object, object o)
    {
      return (object) (bool) (@object.GetType() != o ? 1 : 0);
    }
