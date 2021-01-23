        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            String productsJSON = NavigationContext.QueryString["msg"];
            YourProducts product = JsonConvert.DeserializeObject<YourProducts>(productsJSON);
