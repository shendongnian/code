     <ListView ItemsSource="{Binding Lista}" AlternationCount="{Binding Lista.Count}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Width="40" Text="{Binding (ItemsControl.AlternationIndex),RelativeSource={RelativeSource AncestorType=ListViewItem}}"/>
                        <TextBlock Width="40" Text="{Binding }"/>
                        <Button Width="40" Content="+" Command="{Binding RelativeSource={RelativeSource AncestorType=ListView}, Path=DataContext.Cmd}"
                                CommandParameter="{Binding (ItemsControl.AlternationIndex), RelativeSource={RelativeSource AncestorType=ListViewItem}}"/>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        public ObservableCollection<int> Lista { get; set; }
        private RelayCommand cmd;
        public RelayCommand Cmd
        {
            get { return cmd ?? (cmd = new RelayCommand(new Action<object>(AddRow))); }
        }
        public MainWindow()
        {
            Lista = new ObservableCollection<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            InitializeComponent();
            this.DataContext = this;
        }
        void AddRow(object obj)
        {
            int numer;
            Int32.TryParse(obj.ToString(), out numer);
            Lista.Insert(numer, 55);           
        }
