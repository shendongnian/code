    static string businessnamereturn;
        
     protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
            {
                NavigationService.RemoveBackEntry(); 
                businessnamereturn = NavigationContext.QueryString["Businessname"];
                Locationname.Text = businessnamereturn;
            }
