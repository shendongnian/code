        static ExtendedCheckBox ()
        {
            IsCheckedProperty.OverrideMetadata(typeof(ExtendedCheckBox ), new FrameworkPropertyMetadata(new PropertyChangedCallback(IsCheckedChanged)));
        }
        private static void IsCheckedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var myCheckBox = obj as ExtendedCheckBox ;
            if (myCheckBox != null)
            {
                myCheckBox.IsCheckedAssigned(myCheckBox, new IsCheckedAssignedEventArgs(myCheckBox.IsChecked, e.NewValue));
            }
        }
