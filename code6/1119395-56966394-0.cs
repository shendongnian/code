    <Window x:Class="MyApp.MainWindow"
        ResizeMode="CanResize" 
        WindowStyle="SingleBorderWindow"
        SizeChanged="Window_SizeChanged">
    ....
    Code
    ....
    </Window>
    public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(8);
            }
            else
            {
                this.BorderThickness = new System.Windows.Thickness(0);
            }
        }
