	private void DateTimePicker_ValueChanged(Object sender, EventArgs e) 
	{
		var selectedDate = this.DateTimePicker.Value;
		if (this.DateIsForbidden(selectedDate))
		{
			var forcedDate = this.GetAllowedDate(selectedDate);
			this.DateTimePicker.Value = forcedDate;
			MessageBox.Show(string.Format("Date {0} is not allowed. {1} selected instead", selectedDate, forcedDate));
		}
	}
