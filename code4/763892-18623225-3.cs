      public static IList<DependencyProperty> GetAllProperties(DependencyObject obj)
        {
            return (from PropertyDescriptor pd in TypeDescriptor.GetProperties(obj, new Attribute[] {new PropertyFilterAttribute(PropertyFilterOptions.SetValues)})
                    select DependencyPropertyDescriptor.FromProperty(pd)
                    into dpd where dpd != null select dpd.DependencyProperty).ToList();
        }
        public static void CopyPropertiesFrom(this FrameworkElement controlToSet,
                                                   FrameworkElement controlToCopy)
        {
            foreach (var dependencyValue in GetAllProperties(controlToCopy)
                    .Where((item) => !item.ReadOnly))
                    .ToDictionary(dependencyProperty => dependencyProperty, controlToCopy.GetValue))
            {
                controlToSet.SetValue(dependencyValue.Key, dependencyValue.Value);
            }
        }
