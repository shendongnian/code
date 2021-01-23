    <Grid x:Name="InnerGrid">
        <ItemsControl ItemsSource="{Binding Path=Alerts}"
                      ItemTemplateSelector="{StaticResource AlertDataTemplateSelector}">
        </ItemsControl>
    </Grid>
    public AlertControl()
    {
        this.InitializeComponent();
        InnerGrid.DataContext = this;
    }
