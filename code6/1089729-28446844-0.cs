    public class CustomDictionaryContractResolver : DefaultContractResolver
    {
      public CustomDictionaryContractResolver() : base(true) { }      
    
      protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
      {
        // let the base class do the heavy lifting
        var contract = base.CreateDictionaryContract(objectType);
        // nothing todo if the created type is already our custom dictionary type
        if (IsGenericDefinition(contract.CreatedType, typeof (CustomDictionary<,>)))
          return contract;
        if (IsGenericDefinition(contract.UnderlyingType, typeof(IDictionary<,>)) || (typeof(IDictionary).IsAssignableFrom(contract.UnderlyingType)))
        {        
          contract.CreatedType = typeof(CustomDictionary<,>)
            .MakeGenericType(contract.DictionaryKeyType ?? typeof(object), contract.DictionaryValueType ?? typeof(object));
        
          // Set our object instantiation using the default constructor;
          // You need to modify this, if your custom dictionary does not 
          // have a default constructor.
          contract.DefaultCreator = () => Activator.CreateInstance(contract.CreatedType);              
        }
        return contract;
      }
      static bool IsGenericDefinition(Type type, Type genericDefinition)
      {
        return type.IsGenericType && type.GetGenericTypeDefinition() == genericDefinition;
      }
    }
