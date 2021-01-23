    private class TestCustomTypeProvider : AbstractDynamicLinqCustomTypeProvider, IDynamicLinkCustomTypeProvider
    {
       private HashSet<Type> _customTypes;
       public virtual HashSet<Type> GetCustomTypes()
       {
          if (_customTypes != null)
          {
              return _customTypes;
          }
          _customTypes = new HashSet<Type>(FindTypesMarkedWithDynamicLinqTypeAttribute(new[] { GetType().GetTypeInfo().Assembly }));
                return _customTypes;
        }
    }
