     void ws_ContactUsJSONCompleted(object sender, dynamic e)
            {
                if (e.Error != null)
                {
                    MessageBox.Show(LogIn.NetworkBusyMsg, LogIn.MsgHdr, MessageBoxButton.OK);
                    busyIndicator.IsRunning = false;
                }
                else
                {
                    busyIndicator.IsRunning = false;
                    string Result = e.Result;
                    JObject obj = JObject.Parse(Result);
                    string ResultCode = (string)obj["ResultCode"];
                    string ResponceMessage = (string)obj["ResponseMessage"];
    
                    if (ResultCode == "1")
                    {
                        MessageBox.Show("Thank you for your message. We'll get back to you soon.", LogIn.MsgHdr, MessageBoxButton.OK);
                        NavigationService.GoBack();
                    }
                    else
                    {
        
                    }
                }
            }
