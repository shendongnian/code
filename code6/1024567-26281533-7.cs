    // todo; check if your TEnum is enum && typeCode == TypeCode.Int
    public struct FastEnumIntEqualityComparer<TEnum> : IEqualityComparer<TEnum> 
        where TEnum : struct
    {
    	static class BoxAvoidanceMagic
        {
    		static Func<TEnum, int> _unwrapper;
            static TEnum Identity(TEnum x){return x;}
    		
    		public static int ToInt(TEnum t)
    		{
    			return _unwrapper(t);
    		}
    		
    		static BoxAvoidanceMagic()
    		{
    			Func<TEnum, TEnum> identity = Identity;
    			_unwrapper = Delegate.CreateDelegate(typeof(Func<TEnum, int>), 
                     identity.Method) as Func<TEnum, int>;
    		}
        }
    	
    	public bool Equals(TEnum firstEnum, TEnum secondEnum)
    	{
    		return BoxAvoidanceMagic.ToInt(firstEnum) == 
                   BoxAvoidanceMagic.ToInt(secondEnum);
    	}
    	
    	public int GetHashCode(TEnum firstEnum)
    	{
    		return BoxAvoidanceMagic.ToInt(firstEnum);
    	}
    }
