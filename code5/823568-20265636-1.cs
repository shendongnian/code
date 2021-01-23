[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class EndWorkNeedToBeLaterThanBeginWorkValidationAttribute : ValidationAttribute
{
    public EndWorkNeedToBeLaterThanBeginWorkValidationAttribute()
        : base("The end work needs to be later than the begin work")
    {
    }
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        var endWorkProperty = context.ObjectType.GetProperty("EndWork");
        var beginWorkProperty = context.ObjectType.GetProperty("BeginWork");
        var endWorkValue = endWorkProperty.GetValue(context.ObjectInstance, null);
        var beginWorkValue = beginWorkProperty.GetValue(context.ObjectInstance, null);
        if (beginWorkValue >= endWorkValue)
        {
            return new ValidationResult("The end work needs to be later than the begin work", new List<string> { "EndWork", "BeginWork" });
        }
        return ValidationResult.Success;
    }
}
