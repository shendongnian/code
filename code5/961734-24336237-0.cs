    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Button Content="Press and Hold" PreviewMouseDown="Button_PreviewMouseDown" 
            PreviewMouseUp="Button_PreviewMouseUp" />
        <TextBlock Grid.Column="1" Text="{Binding YourValue}" />
    </Grid>
...
    private DispatcherTimer timer = new DispatcherTimer();
    private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        timer.Interval = TimeSpan.FromMilliseconds(100);
        timer.Tick += Timer_Tick;
        timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        YourValue++;
    }
    private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        timer.Stop();
    }
