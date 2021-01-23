    ViewModelBinder.BindProperties = (namedElements, viewModelType) =>
        {
            var unmatchedElements = new List<FrameworkElement>();
            foreach (var element in namedElements)
            {
                var cleanName = element.Name.Trim('_');
                var parts = cleanName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                var property = viewModelType.GetPropertyCaseInsensitive(parts[0]);
                var interpretedViewModelType = viewModelType;
                for (int i = 1; i < parts.Length && property != null; i++)
                {
                    interpretedViewModelType = property.PropertyType;
                    property = interpretedViewModelType.GetPropertyCaseInsensitive(parts[i]);
                }
                if (property == null)
                {
                    unmatchedElements.Add(element);
                    // Log.Info("Binding Convention Not Applied: Element {0} did not match a property.", element.Name);
                    continue;
                }
                var convention = ConventionManager.GetElementConvention(element.GetType());
                if (convention == null)
                {
                    unmatchedElements.Add(element);
                    // Log.Warn("Binding Convention Not Applied: No conventions configured for {0}.", element.GetType());
                    continue;
                }
                var applied = convention.ApplyBinding(
                    interpretedViewModelType,
                    cleanName.Replace('_', '.'),
                    property,
                    element,
                    convention
                    );
                if (applied)
                {
                    // Log.Info("Binding Convention Applied: Element {0}.", element.Name);
                }
                else
                {
                    // Log.Info("Binding Convention Not Applied: Element {0} has existing binding.", element.Name);
                    unmatchedElements.Add(element);
                }
            }
            return unmatchedElements;
        };
