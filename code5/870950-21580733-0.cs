     List<string> messageboxitm = new List<string>();
     messageboxitm.Add("Okay");
     messageboxitm.Add("Cancel");
     string title = "Confirm Buy";
     string displaymessg = "You must buy the app to go further, do you want to buy the app?"; 
     IAsyncResult result1 = Guide.BeginShowMessageBox(title, displaymessg, messageboxitm, 0, MessageBoxIcon.Alert, new AsyncCallback(OnBuyMessageclosed), null);
    private void OnBuyMessageclosed(IAsyncResult ar)
            {
                int? buttonIndex = Guide.EndShowMessageBox(ar);
                switch (buttonIndex)
                {
                    case 0:
                        Deployment.Current.Dispatcher.BeginInvoke(() => ConfirmBuy("Okay"));
                        break;
                    case 1:
                        Deployment.Current.Dispatcher.BeginInvoke(() => ConfirmBuy("Cancel"));
                        break;
                    default:
                        break;
                }
            }
  
      public void ConfirmBuy(string title)
        {
            if (title == "Okay")
            {
                Dispatcher.BeginInvoke(() =>
                {
                   //Action
                });
            }
            else
            {
                return;
            }
        }
