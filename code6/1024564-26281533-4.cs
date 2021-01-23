    // todo; check if your TEnum is enum && typeCode == TypeCode.Int
    public struct FastEnumIntEqualityComparer<TEnum> : IEqualityComparer<TEnum> 
        where TEnum : struct
    {
    	static class BoxAvoidanceMagic
        {
            static TEnum Identity(TEnum x){return x;}
    		
    		public static Func<TEnum, int> EnumToInt;
    		
    		static BoxAvoidanceMagic()
    		{
    			Func<TEnum, TEnum> identity = Identity;
    			EnumToInt = Delegate.CreateDelegate(typeof(Func<TEnum, int>), 
                    identity.Method) as Func<TEnum, int>;
    		}
        }
    	
    	public bool Equals(TEnum firstEnum, TEnum secondEnum)
    	{
    		return BoxAvoidanceMagic.EnumToInt(firstEnum) == 
                   BoxAvoidanceMagic.EnumToInt(secondEnum);
    	}
    	
    	public int GetHashCode(TEnum firstEnum)
    	{
    		return BoxAvoidanceMagic.EnumToInt(firstEnum);
    	}
    }
