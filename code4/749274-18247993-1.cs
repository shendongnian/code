    public class HEBaseMaterial : ChainEnum
    {
        public static readonly HEBaseMaterial Wood = new HEBaseMaterial(1);
        public static readonly HEBaseMaterial Metal = new HEBaseMaterial(1);
    
        protected HEBaseMaterial(int internalValue) : base(internalValue) { }
    }
