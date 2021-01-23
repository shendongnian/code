    <Page.BottomAppBar>
            <CommandBar>
                <AppBarButton Icon="Preview" Label="Preview">
                    <AppBarButton.Flyout>
                        <MenuFlyout Opened="MenuFlyout_Opened" Closed="MenuFlyout_Closed">
                            <MenuFlyoutItem Text="Fit width" />
                            <MenuFlyoutItem Text="Fit height" />
                            <MenuFlyoutItem Text="Fit page" />
                        </MenuFlyout>
                    </AppBarButton.Flyout>
                </AppBarButton>
            </CommandBar>
        </Page.BottomAppBar>
    private void MenuFlyout_Opened(object sender, object e)
    {
      BottomAppBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
    }
    
    private void MenuFlyout_Closed(object sender, object e)
    {
      BottomAppBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
    }
