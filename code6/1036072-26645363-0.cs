    /// <summary>Type-safe extension methods for parsing Enums.</summary>
    public static partial class EnumExtensions{
      #region Enum Parsing utilities
      /// <summary>Typesafe wrapper for <c>Enum.GetValues(typeof(TEnum).</c></summary>
      public static ReadOnlyCollection<TEnum> EnumGetValues<TEnum>() {
        return new ReadOnlyCollection<TEnum>((TEnum[])(Enum.GetValues(typeof(TEnum))));
      }
      /// <summary>TODO</summary>
     [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
      public static ReadOnlyCollection<string> EnumGetNames<TEnum>() where TEnum : struct {
        return new ReadOnlyCollection<string>((string[])(Enum.GetNames(typeof(TEnum))));
      }
      /// <summary>Typesafe wrapper for <c>Enum.ParseEnum()</c> that automatically checks 
      /// constants for membership in the <c>enum</c>.</summary>
      public static TEnum ParseEnum<TEnum>(string value) where TEnum : struct {
        return ParseEnum<TEnum>(value,true);
      }
      /// <summary>Typesafe wrapper for <c>Enum.ParseEnum()</c> that automatically checks 
      /// constants for membership in the <c>enum</c>.</summary>
      public static TEnum ParseEnum<TEnum>(string value, bool checkConstants) where TEnum : struct {
        TEnum enumValue;
        if (!TryParseEnum<TEnum>(value, out enumValue) && checkConstants) 
              throw new ArgumentOutOfRangeException("value",value,"Enum type: " + typeof(TEnum).Name);
        return enumValue;
      }
      /// <summary>Typesafe wrapper for <c>Enum.TryParseEnum()</c> that automatically checks 
      /// constants for membership in the <c>enum</c>.</summary>
      public static bool TryParseEnum<TEnum>(string value, out TEnum enumValue) where TEnum : struct {
        return Enum.TryParse<TEnum>(value, out enumValue)  
           &&  Enum.IsDefined(typeof(TEnum),enumValue);
      }
      /// <summary>Typesafe wrapper for <c>Enum.ToObject()</c>.</summary>
      /// <typeparam name="TEnum"></typeparam>
      public static TEnum EnumParse<TEnum>(char c, string lookup) {
        if (lookup==null) throw new ArgumentNullException("lookup");
        var index = lookup.IndexOf(c);
        if (index == -1) throw new ArgumentOutOfRangeException("c",c,"Enum Type: " + typeof(TEnum).Name);
        return (TEnum) Enum.ToObject(typeof(TEnum), index);
      }
      #endregion
    }
