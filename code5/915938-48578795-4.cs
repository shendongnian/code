    public static string GetDescription(this object member)
    		{
    			var type = member.GetType();
    
    			var attributes = type.GetCustomAttributes<DescriptionAttribute>(false).ToList();
    
    			return attributes.Any() ? attributes.FirstOrDefault()?.Description : member.GetType().Name;
    		}
