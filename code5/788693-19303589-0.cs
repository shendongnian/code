    private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();
    
            ApplicationBarIconButton saveButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            saveButton.Text = AppResources.EditPage_ApplicationBar_Save;
            saveButton.Click += saveButton_Click;
            ApplicationBar.Buttons.Add(saveButton);
        }
    
        void saveButton_Click(object sender, EventArgs e)
        {
            Settings.SavedCount.Value += 1;
            if(Settings.SavedCount.Value > 50)
            {
                if(MessageBox.Show("Message", "Title", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    // Action for "OK"
                else 
                    // Action for "Cancel"
            } 
        }
