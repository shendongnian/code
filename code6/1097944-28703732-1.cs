    public static void ImplementsInterface(this Type type, Type interface)
    {
        bool implemented = type.GetInterfaces().Contains(interface);
        return implemented;
    }
