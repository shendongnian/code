    public static class EnumExtension
    {
      public static string ToDescription<TEnum>(this TEnum enumValue) where TEnum : struct
      {
        return ReflectionService.GetClassAttribute<DescriptionAttribute>(enumValue);
      }
	}
    enum Type 
    { 
      [Description("One")]
      value1 = 1 
    }
    
    var value = Type.Value1;
    Console.Writeline(value.ToDescription());
