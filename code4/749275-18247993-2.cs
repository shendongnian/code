    public class HEWoodItemTypes : ChainLinkEnum<HEBaseMaterial>
    {
        private static readonly HEBaseMaterial InternalParent = HEBaseMaterial.Wood;
    
        public static readonly HEWoodItemTypes Box = new HEWoodItemTypes(1);
        public static readonly HEWoodItemTypes Crate = new HEWoodItemTypes(1);
    
        protected HEWoodItemTypes(int internalValue) : base(internalValue, InternalParent) { }
    }
    public class HEMetalItemTypes : ChainLinkEnum<HEBaseMaterial>
    {
        private static readonly HEBaseMaterial InternalParent = HEBaseMaterial.Metal;
    
        public static readonly HEMetalItemTypes Box = new HEMetalItemTypes(1);
        public static readonly HEMetalItemTypes Bar = new HEMetalItemTypes(1);
    
        protected HEMetalItemTypes(int internalValue) : base(internalValue, InternalParent) { }
    }
