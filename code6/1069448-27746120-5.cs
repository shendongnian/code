    public class ShiftedRangeAttributeAdapter : DataAnnotationsModelValidator<ShiftedRangeAttribute>
    {
        public ShiftedRangeAttributeAdapter(ModelMetadata metadata, ControllerContext context, ShiftedRangeAttribute attribute)
            : base(metadata, context, attribute)
        {
        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            RangeAttribute attr = this.Attribute.CreateRangeAttribute(this.Metadata.Container);
            return new RangeAttributeAdapter(this.Metadata, this.ControllerContext, attr).GetClientValidationRules();
        }
    }
    ...
    DataAnnotationsModelValidatorProvider.RegisterAdapter(
        typeof(ShiftedRangeAttribute), typeof(ShiftedRangeAttributeAdapter));
