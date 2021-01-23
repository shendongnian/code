    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
        proxy.GetAgeAsyncCompleted += SetAgeText;
        string myName = "Nick";
        proxy.GetAgeAsync(myName);
    }
    private void SetAgeText(object sender, GetAgeCompletedEventArgs e)
    {
        AgeTxtBlck.Text = (string) e.Result[0];
    }
