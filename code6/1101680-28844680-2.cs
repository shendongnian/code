        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var sv = new RestClient();
                this.listView.ItemsSource = await sv.GetUsersAsync();
            }
            catch (Exception exception)
            {
                this.DisplayAlert("Error", exception.Message, "OK");
            }
        }
