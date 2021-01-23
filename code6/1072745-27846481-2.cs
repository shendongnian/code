    public static class myextensions
    {
       public static IEnumerable<T> GetEnumValues<T>()
       {
           Type type = typeof( T );
    
           if (!type.IsEnum)
               throw new Exception( string.Format("{0} is not an enum.", type.FullName ));
    
           FieldInfo[] fields =
               type.GetFields( BindingFlags.Public | BindingFlags.Static );
    
    
           foreach (var item in fields)
               yield return (T)item.GetValue( null );
       }
    
    
      /// <summary>If an attribute on an enumeration exists, this will return that
       /// information</summary>
       /// <param name="value">The object which has the attribute.</param>
       /// <returns>The description string of the attribute or string.empty</returns>
       public static string GetAttributeDescription( this object value )
       {
           string retVal = string.Empty;
           try
           {
               retVal = value.GetType()
                             .GetField( value.ToString() )
                             .GetCustomAttributes( typeof( DescriptionAttribute ), false )
                             .OfType<DescriptionAttribute>()
                             .First()
                             .Description;
    
           }
           catch (NullReferenceException)
           {
               //Occurs when we attempt to get description of an enum value that does not exist
           }
           finally
           {
               if (string.IsNullOrEmpty( retVal ))
                   retVal = "Unknown";
           }
    
           return retVal;
       }
    
    }
