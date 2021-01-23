    private object AddItemToCollectionProperty( Object obj, string propertyName, Object value )
		{
			PropertyInfo prop = obj.GetType().GetProperty( propertyName );
			if( prop != null )
			{
				try
				{
					MethodInfo addMethod = prop.PropertyType.GetMethod( "Add" );
					if(addMethod ==null)
					{
						return obj;
					}
					addMethod.Invoke( prop.GetValue(obj), new object [] { value }  );
				}
				catch( Exception ex )
				{
					Debug.Write( $"Error setting {propertyName} Property Value: {value} Ex: {ex.Message}" );
				}
			}
			else
			{
				Debug.Write( $"{propertyName} Property not found: {value}" );
			}
			return obj;
		}
