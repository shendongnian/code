    public sealed class ShiftedRangeAttribute : ValidationAttribute
    {
        public string MinShiftProperty { get; private set; }
        public string MaxShiftProperty { get; private set; }
        public double Minimum { get; private set; }
        public double Maximum { get; private set; }
        public ShiftedRangeAttribute(double minimum, double maximum, string minShiftProperty, string maxShiftProperty)
        {
            this.Minimum = minimum;
            this.Maximum = maximum;
            this.MinShiftProperty = minShiftProperty;
            this.MaxShiftProperty = maxShiftProperty;
        }
        public ShiftedRangeAttribute(int minimum, int maximum, string minShiftProperty, string maxShiftProperty)
        {
            this.Minimum = minimum;
            this.Maximum = maximum;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            RangeAttribute attr = this.CreateRangeAttribute(value);
            return attr.GetValidationResult(value, validationContext);
        }
        internal RangeAttribute CreateRangeAttribute(object model)
        {
            double min = this.Minimum;
            if (this.MinShiftProperty != null)
            {
                min += Convert.ToDouble(model.GetType().GetProperty(this.MinShiftProperty).GetValue(model));
            }
            double max = this.Maximum;
            if (this.MaxShiftProperty != null)
            {
                max += Convert.ToDouble(model.GetType().GetProperty(this.MaxShiftProperty).GetValue(model));
            }
            return new RangeAttribute(min, max);
        }
    }
