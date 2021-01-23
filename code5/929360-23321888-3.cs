        public virtual bool IsEnumDefined(object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
 
            if (!IsEnum)
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
            Contract.EndContractBlock();
 
            // Check if both of them are of the same type
            Type valueType = value.GetType();
 
            // If the value is an Enum then we need to extract the underlying value from it
            if (valueType.IsEnum)
            {
                if (!valueType.IsEquivalentTo(this))
                    throw new ArgumentException(Environment.GetResourceString("Arg_EnumAndObjectMustBeSameType", valueType.ToString(), this.ToString()));
 
                valueType = valueType.GetEnumUnderlyingType();
            }
 
            // If a string is passed in
            if (valueType == typeof(string))
            {
                string[] names = GetEnumNames();
                if (Array.IndexOf(names, value) >= 0)
                    return true;
                else
                    return false;
            }
 
            // If an enum or integer value is passed in
            if (Type.IsIntegerType(valueType))
            {
                Type underlyingType = GetEnumUnderlyingType();
                // We cannot compare the types directly because valueType is always a runtime type but underlyingType might not be.
                if (underlyingType.GetTypeCodeImpl() != valueType.GetTypeCodeImpl())
                    throw new ArgumentException(Environment.GetResourceString("Arg_EnumUnderlyingTypeAndObjectMustBeSameType", valueType.ToString(), underlyingType.ToString()));
 
                Array values = GetEnumRawConstantValues();
                return (BinarySearch(values, value) >= 0);
            }
        }
