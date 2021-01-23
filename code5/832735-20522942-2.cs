    <DataTemplate DataType="{x:Type ViewModels:MyCustomUserControlViewModel}">
        <Views:MyCustomUserControlView />
    </DataTemplate>
    ...
    public MyCustomUserControlViewModel ChildViewModel { get; } //(in MainContentViewModel)
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
