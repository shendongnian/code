    Deployment.Current.Dispatcher.BeginInvoke(() => {
                List<string> messageboxitm = new List<string>();
                messageboxitm.Add("Yes");
                messageboxitm.Add("No");
                IAsyncResult result = Guide.BeginShowMessageBox("Message", "The alarm has been raised", messageboxitm, 0, MessageBoxIcon.Alert, new AsyncCallback(OnMessageBoxClosed), null);
    
    });
     private void OnMessageBoxClosed(IAsyncResult ar)
            {
                int? buttonIndex = Guide.EndShowMessageBox(ar);
                switch (buttonIndex)
                {
                    case 0:
                       //Do your work
                        break;               
                    default:
                        break;
                }
            }
