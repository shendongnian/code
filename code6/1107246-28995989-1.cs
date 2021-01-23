    private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
    {
        Item yourItem = (sender as Grid).DataContext as Item;
        FrameworkElement element = sender as FrameworkElement;
        if (element != null) FlyoutBase.ShowAttachedFlyout(element);
    }
    // you can also do the same in your menu items:
    private async void sendEmail_Click(object sender, RoutedEventArgs e)
    {
        Item yourItem = (sender as MenuFlyoutItem).DataContext as Item;
        FrameworkElement element = sender as FrameworkElement;
        Windows.ApplicationModel.Email.EmailMessage mail = new Windows.ApplicationModel.Email.EmailMessage();
        mail.Subject = "Leadsheet Position Assignment";
        mail.To.Add(new Windows.ApplicationModel.Email.EmailRecipient(element.Tag.ToString()));
        await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(mail);
    }
