        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("p"))
            {
                MessageBox.Show(NavigationContext.QueryString["p"]);
            }
            else
            {
                MessageBox.Show("error");
            }
        }
