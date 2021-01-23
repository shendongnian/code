    public MyCustomUserControlViewModel ChildViewModel
    {
        get { return childViewModel; }
        private set { childViewModel = value; NotifyPropertyChanged("ChildViewModel"); }
    }
    ...
    <Grid x:Name="mainGrid">
        <!-- Normal objects -->
        <StackPanel>
            <Label Text="Im a label" />
            <TextBox />
        </StackPanel>
        <!-- My Custom Object -->
        <ContentControl x:Name="myUserControl" Content="{Binding ChildViewModel}" />
    </Grid>
