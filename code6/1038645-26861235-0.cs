    public class ModelBindingRegistry : Registry {
        public ModelBindingRegistry() {
            Scan(scan => {
                scan.TheCallingAssembly();
            });
            var dictionary = new ModelBinderMappingDictionary();
            dictionary.Add<Car, CarModelBinder>();
            For<ModelBinderMappingDictionary>().Use(dictionary);
            For<IModelBinderProvider>().Singleton().Use<StructureMapModelBinderProvider>();
        }
    }
