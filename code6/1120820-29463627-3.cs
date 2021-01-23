    private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        var sb = new StringBuilder();
        sb.Append("Angular\n");
        sb.Append(string.Join("\n", Display(DpiType.Angular)));
        sb.Append("\nEffective\n");
        sb.Append(string.Join("\n", Display(DpiType.Effective)));
        sb.Append("\nRaw\n");
        sb.Append(string.Join("\n", Display(DpiType.Raw)));
        this.Content = new TextBox() { Text = sb.ToString() };
    }
    private IEnumerable<string> Display(DpiType type)
    {
        foreach (var screen in System.Windows.Forms.Screen.AllScreens)
        {
            uint x, y;
            screen.GetDpi(type, out x, out y);
            yield return screen.DeviceName + " - dpiX=" + x + ", dpiY=" + y;
        }
    }
