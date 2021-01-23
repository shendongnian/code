    [SecuritySafeCritical]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
    {
    	if (type == null)
    	{
    		throw new ArgumentNullException("type");
    	}
    	if (type is TypeBuilder)
    	{
    		throw new NotSupportedException(Environment.GetResourceString("NotSupported_CreateInstanceWithTypeBuilder"));
    	}
    	if ((bindingAttr & (BindingFlags)255) == BindingFlags.Default)
    	{
    		bindingAttr |= (BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance);
    	}
    	if (activationAttributes != null && activationAttributes.Length > 0)
    	{
    		if (!type.IsMarshalByRef)
    		{
    			throw new NotSupportedException(Environment.GetResourceString("NotSupported_ActivAttrOnNonMBR"));
    		}
    		if (!type.IsContextful && (activationAttributes.Length > 1 || !(activationAttributes[0] is UrlAttribute)))
    		{
    			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonUrlAttrOnMBR"));
    		}
    	}
    	RuntimeType runtimeType = type.UnderlyingSystemType as RuntimeType;
    	if (runtimeType == null)
    	{
    		throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "type");
    	}
    	StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
    	return runtimeType.CreateInstanceImpl(bindingAttr, binder, args, culture, activationAttributes, ref stackCrawlMark);
    }
