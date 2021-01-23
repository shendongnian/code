    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("f82170cc-efe8-4f5e-8209-bc2c27b3f54d")]
    internal interface ICSExtensionMethodExtender 
    {
        bool IsExtension { get; }
    }
    [ComVisible(true)]
    [ComDefaultInterface(typeof(ICSExtensionMethodExtender))]
    public class ExtensionMethodExtender : ICSExtensionMethodExtender
    {
        internal static ICSExtensionMethodExtender Create(bool isExtension)
        {
            var result = new ExtensionMethodExtender(isExtension);
            return (ICSExtensionMethodExtender)ComAggregate.CreateAggregatedObject(result);
        }
 
        private readonly bool _isExtension;
 
        private ExtensionMethodExtender(bool isExtension)
        {
            _isExtension = isExtension;
        }
 
        public bool IsExtension
        {
            get { return _isExtension; }
        }
    }
    private void SetExtension(CodeFunction codeFunction)
    {
        ICSExtensionMethodExtender extender = new ExtensionMethodExtender(true);
        codeFunction.Extender["ExtensionMethod"] = extender;
        codeFunction.IsShared = true;
    }
