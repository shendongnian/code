    public static readonly DependencyProperty ValidationTemplateProperty =
        DependencyProperty.Register("ValidationTemplate",
                                    typeof(ControlTemplate),
                                    typeof(AutoCompleteComboBox),
                                    new FrameworkPropertyMetadata(new ControlTemplate(), OnValidationTemplateChanged));
    private static void OnValidationTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        Validation.SetErrorTemplate(d, (ControlTemplate)e.NewValue);
    }
