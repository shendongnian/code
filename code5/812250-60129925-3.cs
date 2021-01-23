    using System;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    ...
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType == typeof(DbGeography))
            {
                return new CustomModelBinder();
            }
            return null;
        }
    }
