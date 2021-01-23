    private void TabItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        var currentPage = ((PhoneApplicationFrame)Application.Current.RootVisual).Content as MainPage;
        if (ti != null)
        {
            switch (ti.Name)
            {
                case "tabOverview":
                    currentPage.UpdateContent(new OverviewUserControl());
                    break;
                case "tabLogs":
                    currentPage.UpdateContent(new LogsUserControl());
                    break;
            }
        }
    }
