    private void AccountsItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
            FrameworkElement element=sender as FrameworkElement ;
            Account item= element.DataContext as Account ;
           
            xCa = item.Name;
            NavigationService.Navigate(new Uri(string.Format("/ViewAccount.xaml?parameter={0}&action={1}", a.ToString(), "View"), UriKind.Relative));
    }
