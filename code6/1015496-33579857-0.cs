    sealed class ViewViewModelTypeResolver
    {
        private readonly Assembly _assembly;
        private readonly Type _baseViewModelType;
        private readonly string _viewNameSuffix;
        private readonly string _viewModelNameSuffix;
        private readonly Lazy<Dictionary<string, Type>> _views;
        private readonly Lazy<Dictionary<string, Type>> _viewModels;
        private Dictionary<string, Type> Views => _views.Value;
        private Dictionary<string, Type> ViewModels => _viewModels.Value;
        /// <summary>
        /// Resolves Views and ViewModels.
        /// </summary>
        /// <param name="typeFromUiAssembly">Use any type from the UI Assembly.</param>
        /// <param name="baseViewModelType">All view models need to inherit from this type.</param>
        /// <param name="viewNameSuffix">Prism convention is to name your views with a Page suffix.</param>
        /// <param name="viewModelNameSuffix">Prism convention is name your viewmodels with a ViewModel suffix.</param>
        public ViewViewModelTypeResolver(Type typeFromUiAssembly, Type baseViewModelType, string viewNameSuffix = "Page", string viewModelNameSuffix = "ViewModel")
        {
            _baseViewModelType = baseViewModelType;
            _viewNameSuffix = viewNameSuffix;
            _viewModelNameSuffix = viewModelNameSuffix;
            _assembly = typeFromUiAssembly.GetTypeInfo().Assembly;
            _views = new Lazy<Dictionary<string, Type>>(GetViews);
            _viewModels = new Lazy<Dictionary<string, Type>>(GetViewModels);
        }
        /// <summary>
        /// Gets a View type for the given name.
        /// </summary>
        /// <param name="viewTypeName">Name of the view without the suffix.</param>
        public Type GetViewType(string viewTypeName)
        {
            var pageName = string.Concat(viewTypeName, _viewNameSuffix);
            return this.Views[pageName];
        }
        /// <summary>
        /// Gets a ViewModel for the given view type.
        /// </summary>
        /// <param name="viewType">Type of view.</param>
        public Type GetViewModelType(Type viewType)
        {
            var viewModelName = string.Concat(viewType.Name, _viewModelNameSuffix);
            return this.ViewModels[viewModelName];
        }
        /// <summary>
        /// Gets all the View types by finding all types that inherit from Page and are defined in the UI Assembly.
        /// </summary>
        private Dictionary<string, Type> GetViews()
        {
            var types = _assembly.DefinedTypes.Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(UserControl)));
            return types.ToDictionary(typeInfo => typeInfo.Name, typeInfo => typeInfo.AsType(), StringComparer.Ordinal);
        }
        /// <summary>
        /// Gets all the ViewModel types by finding all types that inherit from a base ViewModel type defined in the UI Assembly.
        /// </summary>
        private Dictionary<string, Type> GetViewModels()
        {
            var types = _assembly.DefinedTypes.Where(type => !type.IsAbstract && type.IsSubclassOf(_baseViewModelType));
            return types.ToDictionary(typeInfo => typeInfo.Name, typeInfo => typeInfo.AsType(), StringComparer.Ordinal);
        }
    }
