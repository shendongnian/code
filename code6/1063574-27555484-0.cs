    public  string SomeInfo { get; set; }
            public MainWindow()
            {
                InitializeComponent();
                SomeInfo = GetFirstNameAndLastNameFromDataBase();
                DataContext = this;
            }
    
            private string GetFirstNameAndLastNameFromDataBase()
            {
                string firstName = "firstName";
                string lastName = "lastName";
    
                return string.Format("First Name = {0}, Last Name = {1}", firstName, lastName);
            }
    <Window x:Class="BindingToTextBlock.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <TextBlock Text="{Binding SomeInfo, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"></TextBlock>
        </Grid>
    </Window>
