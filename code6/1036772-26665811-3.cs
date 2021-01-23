    private void OuterContainer_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        MiddleContainer.Visibility = Visibility.Visible;
    }
    private void MiddleContainer_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        MiddleContainer.Visibility = Visibility.Collapsed;
    }
