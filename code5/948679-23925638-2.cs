    public class EqualitySieveBuilder<T>
    {
        public EqualitySieve<T, TProperty> ForProperty<TProperty>(
            Expression<Func<T, TProperty>> propertyExpression)
        {
            return new EqualitySieve<T, TProperty>()
                .ForProperty(propertyExpression);
        }
    }
