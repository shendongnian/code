    void LayoutRoot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        Mouse.OverrideCursor = Cursors.Wait;
        if (this.IsVisible && this.IsLoaded && this.IsMouseOver)
            OnButtonPatient();
    }
