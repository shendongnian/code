    public class DummyModel
    {
        private const decimal MinValue = 0m;
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string LabelName { get; set; }
        //[DecimalValidatorAttrubute(precision: 2, maxdigits: 2, minValue: decimal.MinValue, maxValue: 99.99m)]
        //public decimal Decimal { get; set; }
    }
