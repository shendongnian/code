        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var sv = new RestClient();
                // activate/show spinner here
                this.listView.ItemsSource = await sv.GetUsersAsync();
                // inactivate/hide spinner here
            }
            catch (Exception exception)
            {
                this.DisplayAlert("Error", exception.Message, "OK");
            }
        }
