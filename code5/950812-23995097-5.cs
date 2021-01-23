        Dictionary<string, ViewModelBase> ViewModels
        {
            get;
            set;
        }
        ViewModels = new Dictionary<string, ViewModelBase>();
        ViewModels.Add("Industry", new IndustryViewModel());
        // and so on...
    and assign it in XAML:
        <TabItem Header="Industry">
            <uc:Industry DataContext="{Binding ViewModels[Industry]}"/>
        </TabItem>
