    public void SetCustomFormat(DateTimePicker dateTimePicker, bool twentyFourHour)
    {
       dateTimePicker.ShowUpDown = true;
       dateTimePicker.Format = DateTimePickerFormat.Custom;
       dateTimePicker.CustomFormat = twentyFourHour ? "HH:mm" : "hh:mm tt";
    }
