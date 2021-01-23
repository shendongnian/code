    Microsoft.Phone.Shell.PhoneApplicationService.Current.ContractActivated +=  Application_ContractActivated;
    
    private void Application_ContractActivated(object sender, IActivatedEventArgs e)
    {
            var filePickerContinuationArgs = e as FileOpenPickerContinuationEventArgs;
            if (filePickerContinuationArgs != null)
            {
            // Handle file here
            }
    }
