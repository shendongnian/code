    public static class SimpleValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> IsImage<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Action<T, Bitmap> action)
        {
            return ruleBuilder.SetValidator(new IsImageValidator<T>(action));
        }
    }
