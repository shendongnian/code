    public class EqualitySieveBuilder<T>
    {
        public EqualitySieve<T, TProperty> ForProperty(
            Expression<Func<T, TProperty>> propertyExpression)
        {
            return new EqualitySieveBuilder<ABusinessObject, TProperty>()
                .ForProperty(propertyExpression);
        }
    }
