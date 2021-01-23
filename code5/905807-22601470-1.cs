    <ItemsControl ItemsSource="{Binding}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
 
    Public MainPage()
    {
        InitializeComponent();
        this.DataContext = ViewModel;
    }
