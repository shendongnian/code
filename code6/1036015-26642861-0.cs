	public static string GetFlagsStringFromUInt32Enum<TEnum>(TEnum value)
		where TEnum : struct
	{
		var sb = new StringBuilder();
		
		for(var i = 0; i < 32; ++i)
		{
			var bit = (uint)1 << i;
			if (((uint)(object)value & bit) != 0)
				sb.Append((TEnum)(object)bit).Append(" | ");
		}
		
		if (sb.Length > 0)
			sb.Length -= 3;
			
		return sb.ToString();
	}
