    private void ZoomIn_Click(object sender, RoutedEventArgs e)
    {
        slider1.Value = slider1.Ticks.Select(x => (double?) x)
            .FirstOrDefault(x => x > slider1.Value) ?? slider1.Value;
    }
    private void ZoomOut_Click(object sender, RoutedEventArgs e)
    {
        slider1.Value = slider1.Ticks.Select(x => (double?) x)
            .LastOrDefault(x => x < slider1.Value) ?? slider1.Value;
    }
