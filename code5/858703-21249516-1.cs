    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FixedLengthDelimeterAttribute : Attribute
    {
        public FixedLengthDelimeterAttribute(int orderNumber, int fixedLength)
        {
            this.fixedLength = fixedLength;
            this.orderNumber = orderNumber;
        }
    
        readonly int fixedLength;
    
        readonly int orderNumber;
    
        public int FixedLength { get { return this.fixedLength; } }
    
        public int OrderNumber { get { return this.orderNumber; } }
    }
