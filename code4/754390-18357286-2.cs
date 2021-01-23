    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        if (EHeightCanvas.Visibility == System.Windows.Visibility.Visible)
        {
            e.Cancel = true;
            EHeightCanvas.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
