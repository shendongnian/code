    public async Task<bool> promptUserForOverwrite()
    {
        Dispatcher.BeginInvoke(() =>
            {
                MessageBoxResult cc = MessageBox.Show("You are about to overwrite data.  Proceed?", "Overwrite?", MessageBoxButton.OKCancel);
                if (cc == MessageBoxResult.OK)
                {
                    System.Diagnostics.Debug.WriteLine("MessageBox OK result");
                    return true;
                }
                else
                {
                    return false;
                }
            });
        
    }
    private async void MessageReceivedHandler(ProximityDevice sender, ProximityMessage message)
    {
        System.Diagnostics.Debug.WriteLine("Handler ran");
        var rawMsg = message.Data.ToArray();
        var ndefMessage = NdefMessage.FromByteArray(rawMsg);
        foreach (NdefRecord record in ndefMessage)
        {
            System.Diagnostics.Debug.WriteLine("Record type: " + Encoding.UTF8.GetString(record.Type, 0, record.Type.Length));
            var specType = record.CheckSpecializedType(false);
            if (specType == typeof(NdefTextRecord))
            {
                var textrec = new NdefTextRecord(record);
                updateReceivedText(textrec.Text);
            }
        }
        bool pow = await promptUserForOverwrite();
        if (!pow)
        {
            System.Diagnostics.Debug.WriteLine("Prompt returned");
            //This always hits - pow is always false. 
        }
        if (stance == WriteStage.WRITING && pow)
        {
            //writeToTag(msg);
        }
    }
