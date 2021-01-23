    public DateTime timeValue { get; set; }
    
    timeValue = timePicker.Value.Value;
    
    <TextBlock Name="timeText" Text="{Binding StringFormat=hh:mm}"/>
    
    timeText.DataContext = timeValue;
