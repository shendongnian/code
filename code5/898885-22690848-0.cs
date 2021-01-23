    /// <summary>This method rebuild the context for the parameter type. Naive implementation.</summary>
    protected virtual CreationContext RebuildContextForParameter(CreationContext current, Type parameterType)
    {
        if (parameterType.ContainsGenericParameters)
        {
            return current;
        }
        return new CreationContext(parameterType, current, false);
    }
