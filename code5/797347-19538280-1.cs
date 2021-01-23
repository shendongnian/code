        static ExtendedCheckBox ()
        {
            IsCheckedProperty.OverrideMetadata(typeof(ExtendedCheckBox ), new FrameworkPropertyMetadata(null , new CoerceValueCallback(IsCheckedCoerced)));
        }
        private static object IsCheckedCoerced(DependencyObject obj, object value)
        {
            var myCheckBox = obj as ExtendedCheckBox ;
            if (myCheckBox != null)
            {
                myCheckBox.IsCheckedAssigned(myCheckBox, new IsCheckedAssignedEventArgs(myCheckBox.IsChecked, (bool)value));
            }
            return value;
        }
