    // member variable
    // update the value during the checkbox's CheckChanged event handler
    private bool isChecked;
    private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        ...
        if (isChecked) 
        {
            // do something special
        }
        ...
    }
