    public static readonly DependencyProperty SelectedDateProperty = 
        DependencyProperty.Register("SelectedDate",
                                    typeof(object),
                                    typeof(NullableDatePicker),
                                    new PropertyMetadata(null, SelectedDateChangedCallback));
