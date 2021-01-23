    private void MyDatePicker_OnLoaded(object sender, RoutedEventArgs e)
    {
        var tb = (DatePickerTextBox)myDatePicker.Template.FindName("PART_TextBox", myDatePicker);
        if (tb != null)
        {
            tb.PreviewMouseUp += (s, args) =>
            {
                tb.CaretIndex = 0;
            };
        }
    }
