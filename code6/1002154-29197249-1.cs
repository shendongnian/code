            void c_OnClientFileSending(object Sender, ClientFileSendingArguments R)
            {
                { 
                    try
                    {
						// Set Text is a similar funtion to "updateText" or "changeText" as referenced in that Tutorial you've seen.
						SetText(R.TransferPercentage.ToString());
                    } 
    
                    catch (Exception ex) { MessageBox.Show(ex.Message); } }
            }
