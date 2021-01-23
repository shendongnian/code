    public class AppBootstrapper : Bootstrapper<ShellViewModel> {
        
        private static IValueConverter StringToOpacityConverter = new StringToOpacityConverter();
        public override void Configure() {
            var oldApplyConverterFunc = ConventionManager.ApplyValueConverter;
            ConventionManager.ApplyValueConverter = (binding, bindableProperty, property) => {
                if (bindableProperty == UIElement.Opacity && typeof(string).IsAssignableFrom(property.PropertyType))
                //                                ^^^^^^^           ^^^^^^
                //                             Property in XAML     Property in view-model
                    binding.Converter = StringToOpacityConverter;
                    //                  ^^^^^^^^^^^^^^^^^^^^^^^^^
                    //                 Our converter used here.
                // else we use the default converter
                else
                    oldApplyConverterFunc(binding, bindableProperty, property);
                 
            };
        }
    }
