    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null)
                return new object();
            string strRecdDate = value.AttemptedValue.ToString();
            DateTime curvalue;
            DateTime.TryParse(strRecdDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out curvalue);
            CultureInfo ci = new CultureInfo("en-IN");
            if (curvalue == DateTime.MinValue)
            {
                DateTime.TryParse(strRecdDate, ci, DateTimeStyles.None, out curvalue);
            }
            return curvalue;
        }
 
