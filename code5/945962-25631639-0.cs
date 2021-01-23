    List<string> _myData;
    void rxCharacteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            string error = "";
            try
            {
                if (args.CharacteristicValue != null && args.CharacteristicValue.Length > 0)
                {
                    var values = args.CharacteristicValue.ToArray();
                    string strValue = Encoding.UTF8.GetString(values, 0, values.Length);
                    lock(_myData) //<-- LOCK YOUR OBJECT BEFORE ADDING DATA
                    {
                        _myData.Add(strValue);
                    }                   
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            if (error.Length > 0)
            {
                if (SendMessageToUiEvent != null)
                {
                    SendMessageToUiEvent(error, true, LoggingLevel.Error, "");
                }
            }
        }
