	    public override object ConvertDbValue(object value, Type type)
	    {
	        if (type.IsEnum)
	        {
	            var val = Convert.ToInt32(value);
	            if (!Enum.IsDefined(type, val))
	                throw ExHelper.Argument(Errors.Common_EnumValueNotFound, val, type.FullName);
	            return base.ConvertDbValue(value, type);
	        }
	    }
