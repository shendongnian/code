    private async void OutersAndContactInTel_Holding(object sender, HoldingRoutedEventArgs e)
    {
        try
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;
            if (element.DataContext != null && element.DataContext is Contact && e.HoldingState == Windows.UI.Input.HoldingState.Started)
            {
                Contact selectedContact = (ImOutContact)element.DataContext;
                if (selectedContact.IsOuter)
                {
                    MessageDialog msgToAddContact = new MessageDialog("Voulez-vous vraiment suivre " + selectedContact.Pseudo + " ?");
                    msgToAddContact.Commands.Add(new UICommand("Oui", (UICommandInvokedHandler) =>
                    {
                        AddContactProcess(selectedContact);
                    }));
                    msgToAddContact.Commands.Add(new UICommand("Non"));
                    this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => msgToAddContact.ShowAsync());
                }
                else
                {
                    MessageDialog msgToInviteContact = new MessageDialog("Envoyez une invitation à  l'utilisation de l'application par sms à " + selectedContact.NomPrenom + " ?");
                    msgToInviteContact.Commands.Add(new UICommand("Oui", (UICommandInvokedHandler) =>
                    {
                        SendSmsToInvite(selectedContact);
                    }));
                    msgToInviteContact.Commands.Add(new UICommand("Non"));
                    await msgToInviteContact.ShowAsync();
                }
            }
        }
        catch (Exception ex)
        {
            MessageDialog errorMessage = new MessageDialog(CustomDialogMessage.getMessageContent(CustomDialogMessage.ERROR_MESSAGE));
            this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => errorMessage.ShowAsync());
        }
    }
