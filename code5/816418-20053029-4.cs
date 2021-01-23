    public class NotifyPropertyChangedMap<T> where T : INotifyPropertyChanged
    {
      #region Fields
      private readonly T propertyContainer;
      private readonly Dictionary<string, object> properties;
      #endregion
      #region Constructors
      public NotifyPropertyChangedMap( T propertyContainer )
      {
        Contract.Requires<ArgumentNullException>( propertyContainer != null, "propertyContainer" );
        this.propertyContainer = propertyContainer;
        this.properties = new Dictionary<string, object>();
      }
      #endregion
      #region Get and Set
      public Property Get<Property>( Expression<Func<T, Property>> expression )
      {
        var propName = NotifyPropertyChangedHelper.GetPropertyName( expression );
        if( !properties.ContainsKey( propName ) )
          properties.Add( propName, GetDefault<Property>() );
        return (Property) properties[ propName ];
      }
      public bool Set<Property>( Expression<Func<T, Property>> expression, Property newValue )
      {
        var propName = NotifyPropertyChangedHelper.GetPropertyName( expression );
        if( !properties.ContainsKey( propName ) )
        {
          properties.Add( propName, newValue );
          propertyContainer.RaisePropertyChangedEvent( propName );
        }
        else
        {
          if( EqualityComparer<Property>.Default.Equals( (Property) properties[ propName ], newValue ) )
            return false;
          properties[ propName ] = newValue;
          propertyContainer.RaisePropertyChangedEvent( propName );
        }
        return true;
      }
      #endregion
      #region Implementation
      private static Property GetDefault<Property>()
      {
        var type = typeof( Property );
        return (Property) ( type.IsValueType ? Activator.CreateInstance( type ) : null );
      }
      #endregion
    }
