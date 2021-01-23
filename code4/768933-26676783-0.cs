    //Call this when the form Loads	
    private void AllowTheDatePickersToBeSetToNothing()		
	{
	//This let's you set the DatePicker to nothing
	dtp_X.CustomFormat = " ";
	dtp_X.Format = DateTimePickerFormat.Custom;
	}	
    // Call this when Uploading or Adding the record (_NewRecord) to an SQL database	
    private void Set_The_Field_Value_based_on_the_CustomFormat_of_the_DateTimePickers()
	{
	if (dtp_X.CustomFormat == " ")
		{
		//the date should be null
		_NewRecord.TheDateProperty = SqlDateTime.Null;
		}
	else
		{
		_NewRecord.TheDateProperty = SqlDateTime.Parse(Convert.ToString(dtp_X.Value));
		}
	}
    //This button resets the Custom Format, so that the user has a way to reset the DateTimePicker Control
    private void btn_Reset_dtp_X_Click(object sender, EventArgs e)
	{
	dtp_X.Format = DateTimePickerFormat.Custom;
	dtp_X.CustomFormat = " ";
	}
