    public override object GetValue(object obj)
    {
      StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
      return this.InternalGetValue(obj, ref stackMark);
    }
    
    [SecuritySafeCritical]
    [DebuggerStepThrough]
    [DebuggerHidden]
    internal object InternalGetValue(object obj, ref StackCrawlMark stackMark)
    {
      INVOCATION_FLAGS invocationFlags = this.InvocationFlags;
      RuntimeType runtimeType1 = this.DeclaringType as RuntimeType;
      if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NO_INVOKE) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
      {
    	if (runtimeType1 != (RuntimeType) null && this.DeclaringType.ContainsGenericParameters)
    	  throw new InvalidOperationException(Environment.GetResourceString("Arg_UnboundGenField"));
    	if (runtimeType1 == (RuntimeType) null && this.Module.Assembly.ReflectionOnly || runtimeType1 is ReflectionOnlyType)
    	  throw new InvalidOperationException(Environment.GetResourceString("Arg_ReflectionOnlyField"));
    	else
    	  throw new FieldAccessException();
      }
      else
      {
    	this.CheckConsistency(obj);
    	if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
    	{
    	  RuntimeAssembly executingAssembly = RuntimeAssembly.GetExecutingAssembly(ref stackMark);
    	  if ((Assembly) executingAssembly != (Assembly) null && !executingAssembly.IsSafeForReflection())
    		throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[1]
    		{
    		  (object) this.FullName
    		}));
    	}
    	RuntimeType runtimeType2 = (RuntimeType) this.FieldType;
    	if ((invocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NEED_SECURITY) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
    	  RtFieldInfo.PerformVisibilityCheckOnField(this.m_fieldHandle, obj, this.m_declaringType, this.m_fieldAttributes, (uint) (this.m_invocationFlags & ~INVOCATION_FLAGS.INVOCATION_FLAGS_IS_CTOR));
    	return this.UnsafeGetValue(obj);
      }
    }
