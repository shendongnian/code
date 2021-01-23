    bool OnOff = true;
    
            protected override void OnBackKeyPress(CancelEventArgs e)
            {
                base.OnBackKeyPress(e);
    
                e.Cancel = true;
    
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (this.OnOff)
                    {
                        CustomMessageBox message = new CustomMessageBox
                        {
                            Caption = "Would you like to terminate the transfer?",
                            LeftButtonContent = "Ok",
                            RightButtonContent = "Cancel"
                        };
    
                        message.Dismissed += (sender, args) =>
                        {
                            ((CustomMessageBox)sender).Dismissing += (o, eventArgs) => eventArgs.Cancel = true;
    
                            if (args.Result == CustomMessageBoxResult.LeftButton)
                            {
                                // Code
                            }
                            else if (args.Result == CustomMessageBoxResult.RightButton)
                            {
                                // Code
                            }
                        };
    
                        message.Show();
    
                        this.OnOff = false;
                    }
                    else
                        this.OnOff = true;
    
                });
            }
