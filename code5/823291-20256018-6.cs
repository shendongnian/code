    public static class HtmlHelperExtensions
    {
        public static IHtmlString DisplayIfFor<TModel, TProperty>
            (this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
            where TProperty : ModelMetadata
        {
            string returnValue = string.Empty;
            var modelMetaData = expression.Compile().Invoke(helper.ViewData.Model);
            var containerType = typeof(TModel);
            var containerProperties = containerType.GetProperties();
            var propertyInfo = containerProperties
                .SingleOrDefault(x => x.Name == modelMetaData.PropertyName);
            var attribute = propertyInfo.GetCustomAttributes(false)
                .SingleOrDefault(x => x is DisplayIfAttribute) as DisplayIfAttribute;
            var conditionalTarget = attribute.PropertyName;
            var conditionalTargetValue = (bool)containerType
                .GetProperty(conditionalTarget).GetValue(helper.ViewData.Model);
            if (conditionalTargetValue)
            {
                returnValue = attribute.TrueValue;
            }
            else
            {
                returnValue = attribute.FalseValue;
            }
            return MvcHtmlString.Create(returnValue);
        }
    }
