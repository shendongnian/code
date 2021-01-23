    class DerivedC : BaseC
    {
        public DerivedC() {}  // req'd so you can still create an instance without a BaseC
        public DerivedC(BaseC baseC)
        {
            BaseId = baseC.BaseId;
            BaseName = baseC.BaseName;
        }
        public int DerivedId { get; set; }
        public string DerivedName { get; set; }
    }
