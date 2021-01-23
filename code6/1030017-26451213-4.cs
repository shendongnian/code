         var type = typeof( DynamicQueryable ).Assembly.GetType( "System.Linq.Dynamic.ExpressionParser" );
         FieldInfo field = type.GetField( "predefinedTypes", BindingFlags.Static | BindingFlags.NonPublic );
         Type[] predefinedTypes = (Type[])field.GetValue( null );
         Array.Resize( ref predefinedTypes, predefinedTypes.Length + 1 );
         predefinedTypes[ predefinedTypes.Length - 1 ] = typeof( DbFunctions );
         field.SetValue( null, predefinedTypes );
