    public static class P
    {
        public const string ArticlePage = "/Pages/ArticlePage.xaml";
        public const string OnlineSectionPage = "/Pages/OnlineSectionPage.xaml";
        public const string GalleryPage = "/Pages/GalleryPage.xaml";
        ...
    }
    // in our viewModel
    NavigationService.Navigate(P.ArticlePage);
    // In navigation service
    public void Navigate(string pagePath)
    {
        if (EnsureMainFrame())
        {
            mainFrame.Navigate(new Uri(pagePath, UriKind.RelativeOrAbsolute));
        }
    }
