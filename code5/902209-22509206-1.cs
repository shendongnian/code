    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string name, breed, photo, gender, DOB, price;
            if (NavigationContext.QueryString.TryGetValue("name", out name))
                txtName.Text = name;
            if (NavigationContext.QueryString.TryGetValue("breed", out breed))
                txtBreed.Text = breed;
            if (NavigationContext.QueryString.TryGetValue("gender", out gender))
                txtGender.Text = gender;
            if (NavigationContext.QueryString.TryGetValue("DOB", out DOB))
                txtDOB.Text = DOB;
            if (NavigationContext.QueryString.TryGetValue("price", out price))
                txtPrice.Text = price;
            if (NavigationContext.QueryString.TryGetValue("photo", out photo))
            {
                BitmapImage image = new BitmapImage(new Uri("/PetShop_A2;component/" + photo, UriKind.Relative));
                imgDetails.Source = image;
            }
        }
