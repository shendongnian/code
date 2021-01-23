    using System;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    ...
    public class CustomModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var latitudePropertyValue = bindingContext.ValueProvider.GetValue(string.Concat(bindingContext.ModelName, ".", nameof(DbGeography.Latitude)));
            var longitudePropertyValue = bindingContext.ValueProvider.GetValue(string.Concat(bindingContext.ModelName, ".", nameof(DbGeography.Longitude)));
            if (!string.IsNullOrEmpty(latitudePropertyValue?.AttemptedValue)
                && !string.IsNullOrEmpty(longitudePropertyValue?.AttemptedValue))
            {
                if (decimal.TryParse(latitudePropertyValue.AttemptedValue, out decimal latitude)
                    && decimal.TryParse(longitudePropertyValue.AttemptedValue, out decimal longitude))
                {
                    // 4326 is equivalent to WGS84 Datum
                    // This is fairly standard, but may need to be careful to use correct one here
                    // Also, this is not a typo - longitude does come before latitude here
                    return DbGeography.FromText($"POINT ({longitude} {latitude})", 4326);
                }
            }
            return null;
        }
    }
