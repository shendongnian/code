        public class ViewViewModelTypeResolver
        {
            private const string ViewNameSuffix = "Page"; // You can change this View name suffix
            private const string ViewModelNameSuffix = "ViewModel"; // You can change this ViewModel name suffix
            private readonly Lazy<Dictionary<string, Type>> _uiAssemblyExportedTypes;
    
            private Dictionary<string, Type> UiAssemblyExportedTypes
            {
                get { return _uiAssemblyExportedTypes.Value; }
            }
    
            public ViewViewModelTypeResolver(Type typeFromUiAssembly)
            {
                _uiAssemblyExportedTypes = new Lazy<Dictionary<string, Type>>(() => GetUiAssemblyExportedTypes(typeFromUiAssembly));
            }
    
            public Type GetViewType(string viewTypeName)
            {
                return UiAssemblyExportedTypes[viewTypeName];
            }
    
            public Type GetViewModelType(Type viewType)
            {
                var pageNameWithoutSuffix = viewType.Name.Remove(viewType.Name.LastIndexOf(ViewNameSuffix, StringComparison.Ordinal));
                var viewModelName = String.Concat(pageNameWithoutSuffix, ViewModelNameSuffix);
                return UiAssemblyExportedTypes[viewModelName];
            }
    
    
            private static Dictionary<string, Type> GetUiAssemblyExportedTypes(Type typeFromUiAssembly)
            {
                return typeFromUiAssembly.GetTypeInfo().Assembly.ExportedTypes.ToDictionary(type => type.Name, type => type, StringComparer.Ordinal);
            }
        }
