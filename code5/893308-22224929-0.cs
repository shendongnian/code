    private void DatePicker_DateValidationError(object sender, DatePickerDateValidationErrorEventArgs e)
    		{
    
    			var MyDatePicker = sender as DatePicker;
    
    			DatePickerTextBox dateBox = MyDatePicker.GetVisualDescendants().OfType<DatePickerTextBox>().FirstOrDefault();
    			if (dateBox != null)
    			{
    				dateBox.Text = String.Empty;
    			}
    			// clear the SelectedDate property too, otherwise you'll be left with the last valid one
    			MyDatePicker.SelectedDate = null;
    		}
