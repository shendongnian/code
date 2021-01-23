    public class DynamicDictionaryModelBinder : DefaultModelBinder
    {
        public override object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var model = bindingContext.Model;
            var modelType = bindingContext.ModelType;
            if (model == null)
            {
                model = this.CreateModel(controllerContext, bindingContext, modelType);
            }
            var dictionaryBindingContext = new ModelBindingContext()
                                            {
                                                ModelMetadata =
                                                    ModelMetadataProviders.Current
                                                    .GetMetadataForType(() => model, modelType),
                                                ModelName = bindingContext.ModelName,
                                                ModelState = bindingContext.ModelState,
                                                PropertyFilter = bindingContext.PropertyFilter,
                                                ValueProvider = bindingContext.ValueProvider
                                            };
            return this.UpdateDynamicDictionary(controllerContext, dictionaryBindingContext);
        }
        private static KeyValuePair<string, object> CreateEntryForModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext,
            Type valueType,
            IModelBinder valueBinder,
            string modelName,
            string modelKey)
        {
            var valueBindingContext = new ModelBindingContext()
            {
                ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, valueType),
                ModelName = modelName,
                ModelState = bindingContext.ModelState,
                PropertyFilter = bindingContext.PropertyFilter,
                ValueProvider = bindingContext.ValueProvider
            };
            
            var thisValue = valueBinder.BindModel(controllerContext, valueBindingContext);
            return new KeyValuePair<string, object>(modelKey, thisValue);
        }
        private object UpdateDynamicDictionary(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var modelList = new List<KeyValuePair<string, object>>();
            var enumerableValueProvider = bindingContext.ValueProvider as IEnumerableValueProvider;
            if (enumerableValueProvider != null)
            {
                var keys = enumerableValueProvider.GetKeysFromPrefix(bindingContext.ModelName);
                var groups = keys.GroupBy((k) => k.Key.Split('[')[0]);
                foreach (var group in groups)
                {
                    if (group.Count() > 1)
                    {
                        var valueType = typeof(ICollection<ExpandoObject>);
                        modelList.Add(
                            CreateEntryForModel(
                                controllerContext,
                                bindingContext,
                                valueType,
                                Binders.GetBinder(valueType),
                                bindingContext.ModelName + '.' + group.Key,
                                group.Key));
                    }
                    else
                    {
                        var item = group.Single();
                        var value = bindingContext.ValueProvider.GetValue(item.Value);
                        var valueType = value != null && value.RawValue != null ?
                                typeof(object) : typeof(ExpandoObject);
                        modelList.Add(
                            CreateEntryForModel(
                                controllerContext,
                                bindingContext,
                                valueType,
                                Binders.GetBinder(valueType),
                                item.Value,
                                item.Key));
                    }
                }
                
            }
            var dictionary = (IDictionary<string, object>)bindingContext.Model;
            foreach (var kvp in modelList)
            {
                dictionary[kvp.Key] = kvp.Value;
            }
            return dictionary;
        }
    }
