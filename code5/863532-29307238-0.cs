    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("f82170cc-efe8-4f5e-8209-bc2c27b3f54d")]
    internal interface ICSExtensionMethodExtender
    {
        bool IsExtension { get; }
    }
    private bool IsExtensionMethod(CodeFunction codeFunction)
    {
        ICSExtensionMethodExtender extender = codeFunction.Extender["ExtensionMethod"] as ICSExtensionMethodExtender;
        return codeFunction.IsShared && extender != null && extender.IsExtension;
    }
