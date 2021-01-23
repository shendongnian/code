    private void LanchDatePicker()
    {
        datepicker = new CustomDatePicker
        {
            IsTabStop = false, 
            MaxHeight = 0,
            Value = null
        };
        
       datepicker.ValueChanged += DatePicker_OnValueChanged;
       LayoutRoot.Children.Add(datepicker);
       datepicker.ClickTemplateButton();
    }
