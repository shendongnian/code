    public static object InvokeBaseMethod(object obj, string methodName, Type baseType, Type equivalentBaseInterface, params object[] arguments)
    {
        Type baseInterface = baseType.GetInterfaces().First((t) => t.GUID == equivalentBaseInterface.GUID);
        ComMemberType type = ComMemberType.Method;
        int methodSlotNumber = Marshal.GetComSlotForMethodInfo(equivalentBaseInterface.GetMethod(methodName));
        MethodInfo baseMethod = (MethodInfo)Marshal.GetMethodInfoForComSlot(baseInterface, methodSlotNumber, ref type);
        return baseMethod.Invoke(obj, arguments);
    }
