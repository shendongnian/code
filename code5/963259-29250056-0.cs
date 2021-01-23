    public Bootstrapper()
    {
    ConventionManager.AddElementConvention<DXTabControl>(DXTabControl.ItemsSourceProperty, "ItemsSource", "DataContextChanged")
                .ApplyBinding = (viewModelType, path, property, element, convention) =>
            {
                if (!ConventionManager.SetBindingWithoutBindingOrValueOverwrite(viewModelType, path, property, element, convention, DXTabControl.ItemsSourceProperty))
                {
                    return false;
                }
                var tabControl = (DXTabControl)element;
                if (tabControl.ItemTemplate == null && tabControl.ItemTemplateSelector == null && property.PropertyType.IsGenericType)
                {
                    var itemType = property.PropertyType.GetGenericArguments().First();
                    if (!itemType.IsValueType && !typeof(string).IsAssignableFrom(itemType))
                    {
                        tabControl.ItemTemplate = ConventionManager.DefaultItemTemplate;
                    }
                }
                ConventionManager.ConfigureSelectedItem(element, Selector.SelectedItemProperty, viewModelType, path);
                if (string.IsNullOrEmpty(tabControl.DisplayMemberPath))
                {
                    ConventionManager.ApplyHeaderTemplate(tabControl, DXTabControl.ItemHeaderTemplateProperty, DXTabControl.ItemHeaderTemplateSelectorProperty, viewModelType);
                }
                return true;
            };
    [...]
    }
