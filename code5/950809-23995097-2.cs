        Dictionary<string, ViewModelBase> ViewModels
        {
            get;
            set;
        }
    and assign it in XAML:
        <TabItem Header="Industry">
            <uc:Industry DataContext="{Binding ViewModels[Industry]}"/>
        </TabItem>
