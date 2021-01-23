    private void AdControl_ErrorOccurred(object sender, Microsoft.Advertising.WinRT.UI.AdErrorEventArgs e)
        {
            try
            {
                var errorType = Enum.GetName(typeof(MicrosoftAdvertising.ErrorCode), e.ErrorCode);
                var adControl = sender as Microsoft.Advertising.WinRT.UI.AdControl;
                
                // Do something with the above information.
            }
            catch (Exception ex)
            {
               // Do something with the exception.
            }
        }
