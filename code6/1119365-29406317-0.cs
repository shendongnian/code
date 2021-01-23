    [BaseType (typeof(NSObject))]
        public partial interface Constants
        {
            [Export ("ApplicationKey")]
            byte[] ApplicationKey { get; set; }
        }
