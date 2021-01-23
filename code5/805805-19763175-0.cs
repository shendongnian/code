    public static class EnumExtension
    {
      public static string ToDescription<TEnum>(this TEnum enumValue, string value) where TEnum : struct
      {
        var description = ReflectionService.GetClassAttribute<DescriptionAttribute>(enumValue);
        return string.Format(description.Description, value);
      }
	}
    enum Type 
    { 
      [Description("One")]
      value1 = 1 
    }
    
    var value = Type.Value1;
    Console.Writeline(value.ToDescription());
