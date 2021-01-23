    public bool IsClass {
                [Pure] 
                get {return ((GetAttributeFlagsImpl() & TypeAttributes.ClassSemanticsMask) == TypeAttributes.Class && !IsValueType);}
            } 
    ...
     public bool IsValueType {
                [Pure] 
                get {return IsValueTypeImpl();}
            } 
    ...
     protected virtual bool IsValueTypeImpl() 
            {
                // Note that typeof(Enum) and typeof(ValueType) are not themselves value types. 
                // But there is no point excluding them here because customer derived System.Type
                // (non-runtime type) objects can never be equal to a runtime type, which typeof(XXX) is.
                // Ideally we should throw a NotImplementedException here or just return false because
                // customer implementations of IsSubclassOf should never return true between a non-runtime 
                // type and a runtime type. There is no benefits in making that breaking change though.
     
                return IsSubclassOf(RuntimeType.ValueType); 
            }
