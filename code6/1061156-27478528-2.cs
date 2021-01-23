    <!-- language: xaml -->
        <Page x:Class="Example81.PageWithAppBar"
              xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
              xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
              <Frame Name="rootFrame"></Frame>
    
              <Page.BottomAppBar>
                 <CommandBar>
                   <AppBarButton Icon="Help" Label="Ask"/>
                 </CommandBar>
              </Page.BottomAppBar>
        </Page>
    <!-- language: c# -->
        // we need to expose the frame
        public sealed partial class PageWithAppBar : Page
        {
            public Frame RootFrame { get { return rootFrame; } }
            // rest ...
    <!-- language: c# -->
        // app.xam.cs launched event
        PageWithAppBar rootPage;
        public CommandBar MyAppBar { get { return rootPage.BottomAppBar as CommandBar; } }
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            rootPage = Window.Current.Content as PageWithAppBar;
            if (rootPage == null)
            {
                rootPage = new PageWithAppBar();
                rootPage.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
                Window.Current.Content = rootPage;
            }
            if (rootPage.RootFrame.Content == null)
                rootPage.RootFrame.Navigate(typeof(MainPage), e.Arguments);
            Window.Current.Activate();
        }
