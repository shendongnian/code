    private boolean IsInteger(object expression)
    {
        var numericTypes = new HashSet<Type>(
                                            {
                                                 typeof(Byte),
                                                 typeof(SByte),
                                                 typeof(Int16),
                                                 typeof(UInt16),
                                                 typeof(Int32),
                                                 typeof(UInt32)
                                            })
        return expression != null && numericTypes.Contains(expression.GetType())
    }
