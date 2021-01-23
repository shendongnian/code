    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string modelName = bindingContext.ModelName;
            var elementType = (int)bindingContext.ValueProvider.GetValue(string.Format("{0}.ElementType", modelName)).ConvertTo(typeof(int));
            if (elementType == 1)
            {
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => new IISElement(), typeof(IISElement));
            }
            else if (elementType == 2)
            {
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => new SharePointElement(), typeof(SharePointElement));
            }
            else if (elementType == 3)
            {
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => new SQLElement(), typeof(SQLElement));
            }
            else if (elementType == 12)
            {
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => new SharedElement(), typeof(SharedElement));
            }
            else
            {
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => new BaseProjectElement(), typeof(BaseProjectElement));
            }
            return base.BindModel(controllerContext, bindingContext);
        }
