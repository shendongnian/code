    public void CellEditEndingEvent(object Sender, DataGridCellEditEndingEventArgs e)
    {  
        if(String.Equals(e.Column.Header.ToString(), "YourCheckBoxFieldName")
        {
            var x = e.Row.Item as YourType;
            if(null != x)
            {
                e.EditingElement.IsEnabled = x.IsHolidayYN;
            }
        }            
    }
