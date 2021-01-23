    public static Type GetNullableUnderlyingTypeOrTypeIfNonNullable(this Type possiblyNullableType)
    {
    	var nullableType = Nullable.GetUnderlyingType(possiblyNullableType);
    	
    	bool isNullableType = nullableType != null;
    	
    	if (isNullableType)
    		return nullableType;
    	else
    		return possiblyNullableType;
    }
