     protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                selectedItemID = Convert.ToInt32(this.NavigationContext.QueryString["SelectedIndex"]);
            }
            catch
            {
                MessageBox.Show("An error occured finding selecteditem", "Error", MessageBoxButton.OK);
            }
        }
