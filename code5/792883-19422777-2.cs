    public void NavigateToPage(YouPageClass page)
    {
        page.NavigationService.Navigate(new Uri("/Pages/PageToNavigateTo.xaml",
            UriKind.RelativeOrAbsolute));
    }
