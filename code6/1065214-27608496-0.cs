    private void RFID_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {   Debug.WriteLine("StackTrace: '{0}'", Environment.StackTrace);         
        try
        {                
            tag_id = RFID.ReadExisting().ToString();              
            SetLabel(tag_id);                
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
