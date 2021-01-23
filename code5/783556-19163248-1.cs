     public static readonly DependencyProperty ValidationTemplateProperty =
            DependencyProperty.Register("ValidationTemplate"
                                        , typeof(ControlTemplate)
                                        , typeof(AutoCompleteComboBox)
                                        , new FrameworkPropertyMetadata(new ControlTemplate(),ValidationTemplateChanged));
    
        private static void ValidationTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AutoCompleteComboBox control = d as AutoCompleteComboBox;
            control.Resources["MyErrorTemplate"] = e.NewValue;
        }
