    public static class JobHelper
    {
        public static object ConvertType(this object value, Type destinationType)
        {
            var sourceType = value.GetType();
            TypeConverter converter = TypeDescriptor.GetConverter(sourceType);
            if (converter.CanConvertTo(destinationType))
            {
                return converter.ConvertTo(value, destinationType);
            }
            converter = TypeDescriptor.GetConverter(destinationType);
            if (converter.CanConvertFrom(sourceType))
            {
                return converter.ConvertFrom(value);
            }
            throw new Exception(string.Format("Cant convert value '{0}' or type {1} to destination type {2}", value, sourceType.Name, destinationType.Name));
        }
        public static Job CreateJob<T>(Expression<Action<T>> expression, params object[] args)
        {
            MethodCallExpression outermostExpression = expression.Body as MethodCallExpression;
            var methodName = outermostExpression.Method.Name;
            return Job.FromExpression<JobContext<T>>(ctx => ctx.Execute(methodName, args));
        }
    }
