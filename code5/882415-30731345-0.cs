    public DefaultServices(HttpConfiguration configuration)
        {
          if (configuration == null)
            throw System.Web.Http.Error.ArgumentNull("configuration");
          this._configuration = configuration;
          this.SetSingle<IActionValueBinder>((IActionValueBinder) new DefaultActionValueBinder());
          this.SetSingle<IApiExplorer>((IApiExplorer) new ApiExplorer(configuration));
          this.SetSingle<IAssembliesResolver>((IAssembliesResolver) new DefaultAssembliesResolver());
          this.SetSingle<IBodyModelValidator>((IBodyModelValidator) new DefaultBodyModelValidator());
          this.SetSingle<IContentNegotiator>((IContentNegotiator) new DefaultContentNegotiator());
          this.SetSingle<IDocumentationProvider>((IDocumentationProvider) null);
          this.SetMultiple<IFilterProvider>((IFilterProvider) new ConfigurationFilterProvider(), (IFilterProvider) new ActionDescriptorFilterProvider());
          this.SetSingle<IHostBufferPolicySelector>((IHostBufferPolicySelector) null);
          this.SetSingle<IHttpActionInvoker>((IHttpActionInvoker) new ApiControllerActionInvoker());
          this.SetSingle<IHttpActionSelector>((IHttpActionSelector) new ApiControllerActionSelector());
          this.SetSingle<IHttpControllerActivator>((IHttpControllerActivator) new DefaultHttpControllerActivator());
          this.SetSingle<IHttpControllerSelector>((IHttpControllerSelector) new DefaultHttpControllerSelector(configuration));
          this.SetSingle<IHttpControllerTypeResolver>((IHttpControllerTypeResolver) new DefaultHttpControllerTypeResolver());
          this.SetSingle<ITraceManager>((ITraceManager) new TraceManager());
          this.SetSingle<ITraceWriter>((ITraceWriter) null);
          this.SetMultiple<ModelBinderProvider>((ModelBinderProvider) new TypeConverterModelBinderProvider(), (ModelBinderProvider) new TypeMatchModelBinderProvider(), (ModelBinderProvider) new KeyValuePairModelBinderProvider(), (ModelBinderProvider) new ComplexModelDtoModelBinderProvider(), (ModelBinderProvider) new ArrayModelBinderProvider(), (ModelBinderProvider) new DictionaryModelBinderProvider(), (ModelBinderProvider) new CollectionModelBinderProvider(), (ModelBinderProvider) new MutableObjectModelBinderProvider());
          this.SetSingle<ModelMetadataProvider>((ModelMetadataProvider) new DataAnnotationsModelMetadataProvider());
          this.SetMultiple<ModelValidatorProvider>((ModelValidatorProvider) new DataAnnotationsModelValidatorProvider(), (ModelValidatorProvider) new DataMemberModelValidatorProvider());
          this.SetMultiple<ValueProviderFactory>((ValueProviderFactory) new QueryStringValueProviderFactory(), (ValueProviderFactory) new RouteDataValueProviderFactory());
          this.SetSingle<IModelValidatorCache>((IModelValidatorCache) new ModelValidatorCache(new Lazy<IEnumerable<ModelValidatorProvider>>((Func<IEnumerable<ModelValidatorProvider>>) (() => ServicesExtensions.GetModelValidatorProviders((ServicesContainer) this)))));
          this.SetSingle<IExceptionHandler>((IExceptionHandler) new DefaultExceptionHandler());
          this.SetMultiple<IExceptionLogger>();
          this._serviceTypesSingle = new HashSet<Type>((IEnumerable<Type>) this._defaultServicesSingle.Keys);
          this._serviceTypesMulti = new HashSet<Type>((IEnumerable<Type>) this._defaultServicesMulti.Keys);
          this.ResetCache();
        }
