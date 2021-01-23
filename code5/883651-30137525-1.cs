    private void gender_SelectionChanged(object sender, SelectionChangedEventArgs e)  
        {
            if (gender.SelectedValue == "Male")
            {
                sex.Text = "m";
            }
            if (gender.SelectedValue == "Female")
            {
                sex.Text = "f";
            }
        }
