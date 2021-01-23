    private static bool _isClosure(Action a)
    {
        var typ = a.Target.GetType();
        var isInvisible = !typ.IsVisible;
        var isCompilerGenerated = Attribute.IsDefined(typ, typeof(CompilerGeneratedAttribute));
        var isNested = typ.IsNested && typ.MemberType == MemberTypes.NestedType;
        return isNested && isCompilerGenerated && isInvisible;
    }
