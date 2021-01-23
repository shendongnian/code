    private void GetStaffData(int p_persoon, UIElement printCard)
    {
        PictureServiceClient proxy = new PictureServiceClient();
        proxy.GetPersonelCardInfoCompleted += this.Proxy_GetPersonelCardInfoCompleted;
        proxy.GetPersonelCardInfoAsync(p_persoon, printCard);
    }
    private void Proxy_GetPersonelCardInfoCompleted(object sender, GetPersonelCardInfoCompletedEventArgs e)
    {
        UIElement printCard = (UIElement)e.UserState;
        // do stuff 
    }
