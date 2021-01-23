    public class DataItemModelBinder: DefaultModelBinder {
		protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType) {
			GenericModel model = CreateGenricModel(controllerContext, bindingContext);
			//this is basically a factory that creates the correct IDataItem 
			// given the newly hydrated GenericModel. It doesn't really apply
			// for the given question/answer so I left it out.
			return CreateDataItem(model);
		}
		private IDataItem CreateDataItem(GenericModel genericModel) {
			IModelRetriever retriever = GetRetreiver(genericModel.DataType);
			return retriever.GetModel(genericModel);
		}
		private GenericModel CreateGenricModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
			GenericModel model = new GenericModel();
			ModelBindingContext context = CreateGenericFieldBindingContext(bindingContext, model);
			foreach (PropertyDescriptor descriptor in GetFilteredModelProperties(controllerContext, context)) {
				string prefix = CreateSubPropertyPrefix(context.ModelName, descriptor.Name);
				ModelBindingContext propertyContext = new ModelBindingContext {
					ModelMetadata = context.PropertyMetadata[descriptor.Name],
					ModelName = prefix,
					ValueProvider = context.ValueProvider
				};
				IModelBinder propertyBinder = Binders.GetBinder(descriptor.PropertyType);
				object value = GetPropertyValue(controllerContext, propertyContext, descriptor, propertyBinder);
				SetProperty(controllerContext, context, descriptor, value);
			}
			return model;
		}
		private ModelBindingContext CreateGenericFieldBindingContext(ModelBindingContext bindingContext, GenericModel model) {
			return new ModelBindingContext {
				ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, typeof(GenericModel)),
				ValueProvider = bindingContext.ValueProvider,
				ModelName = bindingContext.ModelName
			};
		}
		
		private string CreateSubPropertyPrefix(string prefix, string propertyName) {
			if (string.IsNullOrEmpty(prefix))
				return propertyName;
			if (string.IsNullOrEmpty(propertyName))
				return prefix;
			return (prefix + "." + propertyName);
		}	
	}
