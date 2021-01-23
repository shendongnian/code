    public class ChainEnum
    {
        public int IntValue { get; protected set; }
    
        public static readonly ChainEnum None = new ChainEnum(1);
    
        protected ChainEnum(int internalValue)
        {
            this.IntValue = internalValue;
        }
    }
    
    public class ChainLinkEnum<TParent> : ChainEnum where TParent : ChainEnum
    {
        public TParent Parent { get; protected set; }
    
        protected ChainLinkEnum(int internalValue, TParent aParent)
            : base(internalValue)
        {
            Parent = aParent;
        }
    }
