    [DebuggerHidden]
    [DebuggerStepThrough]
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public override object GetValue(object obj)
    {
      return this.GetValue(false);
    }
    [SecuritySafeCritical]
    private object GetValue(bool raw)
    {
      object obj = MdConstant.GetValue(this.GetRuntimeModule().MetadataImport, this.m_tkField, this.FieldType.GetTypeHandleInternal(), raw);
      if (obj == DBNull.Value)
    	throw new NotSupportedException(Environment.GetResourceString("Arg_EnumLitValueNotFound"));
      else
    	return obj;
    }
