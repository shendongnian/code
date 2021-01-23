    public class BaseClass
    {
        public BaseClass() { Index = 1; }
        [DefaultValue(1)]
        public int Index { get; set; }
    }
    public class MidClass : BaseClass
    {
        public MidClass() : base() { MidDouble = 1.0; }
        [DefaultValue(1.0)]
        public double MidDouble { get; set; }
    }
    public class DerivedClass : MidClass
    {
        public DerivedClass() : base() { DerivedString = string.Empty; }
        [DefaultValue("")]
        public string DerivedString { get; set; }
    }
    public class VeryDerivedClass : DerivedClass
    {
        public VeryDerivedClass() : base() { this.VeryDerivedIndex = -1; }
        [DefaultValue(-1)]
        public int VeryDerivedIndex { get; set; }
    }
