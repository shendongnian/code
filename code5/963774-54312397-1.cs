        public static IEnumerable<BindingExpression> GetBindings<T>(this T element, Func<DependencyProperty, bool> func = null) where T : DependencyObject
                {
                    var properties = element.GetType().GetDependencyProperties();
                    foreach (var i in properties)
                    {
                        var binding = BindingOperations.GetBindingExpression(element, i);
                        if (binding == null)
                            continue;
                        yield return binding;
                    }
                }
    
    
    private static readonly ConcurrentDictionary<Type, DependencyProperty[]> DependencyProperties = new ConcurrentDictionary<Type, DependencyProperty[]>();
        public static DependencyProperty[] GetDependencyProperties(this Type type)
                {
                    return DependencyProperties.GetOrAdd(type, t =>
                    {
                        var properties = GetDependencyProperties(TypeDescriptor.GetProperties(type, new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }));
                        return properties.ToArray();
                    });
                }
        
                private static IEnumerable<DependencyProperty> GetDependencyProperties(PropertyDescriptorCollection collection)
                {
                    if (collection == null)
                        yield break;
                    foreach (PropertyDescriptor i in collection)
                    {
                        var dpd = DependencyPropertyDescriptor.FromProperty(i);
                        if (dpd == null)
                            continue;
                        yield return dpd.DependencyProperty;
                    }
                }
