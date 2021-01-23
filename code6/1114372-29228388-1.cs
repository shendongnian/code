    public BaseViewModel ViewModel { get; set; }
...
    <DataTemplate DataType="{x:Type ViewModels:LoginViewModel}">
        <Views:LoginView />
    </DataTemplate>
    <DataTemplate DataType="{x:Type ViewModels:RegisterViewModel}">
        <Views:RegisterView />
    </DataTemplate>
