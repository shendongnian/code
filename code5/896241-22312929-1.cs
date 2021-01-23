    private void OnClickedInUserControl(object sender, RoutedEventArgs e)
    {
        ParentControl parmain = new ParentControl();
        this.gridMain.Children.Add(parmain);
        parmain.Visibility = System.Windows.Visibility.Visible;
        // also remove the original usercontrol from the grid and collapse it's vilisibilty
    }
