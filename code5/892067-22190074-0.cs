    public static class EnumExtensions {
      // This extension method requires "value" argument
      // that should be an instance of Enum class 
      public static string GetDescriptionAttr(this Enum value, string key) {
        ...
      }
    }
    
    ...
    
    public enum MyEnum {
      One, 
      Two,
      Three
    }
    
    Enum myEnum = MyEnum.One;
    
    // You can call extension method on instance (myEnum) only
    myEnum.GetDescriptionAttr("One");
