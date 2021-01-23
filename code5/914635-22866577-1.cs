    public class UnitsViewModel
    {
        public List<Unit> Units { get; set; }
        public class Unit
        {
            [HiddenInput(DisplayValue = false)]
            public int UnitId { get; set; }
            [DataType(DataType.MultilineText)]
            public string Name { get; set; }
            [DataType(DataType.MultilineText)]
            public string ErrorText { get; set; }
        }
    }
