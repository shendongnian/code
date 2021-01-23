    public void SetCustomFormat(DateTimePicker dateTimePicker, bool twentyFourHour)
    {
       dateTimePicker.Format = DateTimePickerFormat.Custom;
       dateTimePicker.CustomFormat = twentyFourHour ? "HH:mm" : "hh:mm tt";
    }
