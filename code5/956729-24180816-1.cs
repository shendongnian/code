    <Grid PreviewMouseDown="OnPreviewMouseDown" Background="Transparent">
        <Label Name="SomeName" Visibility="Hidden" Content="Something" />
    </Grid>
...
    private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        SomeName.Visibility = Visibility.Visible;
    }
