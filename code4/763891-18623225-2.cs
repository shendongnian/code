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
