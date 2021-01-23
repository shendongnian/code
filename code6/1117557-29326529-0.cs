        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int x;
            if (int.TryParse(e.Parameter.ToString(), out x))
            {
                textText.Text=CountryList[x].Name
            }
            else
            {
                textText.Text="--Select your Country--";
            }
        }
