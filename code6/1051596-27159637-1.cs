    HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    async void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            else
            {
                var msg = new MessageDialog("Zamknąć aplikację?");
                var okBtn = new UICommand("Tak");
                var cancelBtn = new UICommand("Nie");
                msg.Commands.Add(okBtn);
                msg.Commands.Add(cancelBtn);
                IUICommand result = await msg.ShowAsync();
                if (result != null && result.Label == "Tak")
                {
                    Application.Current.Exit();
                }
            }
        }
