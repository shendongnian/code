XAML
    <Window x:Class="TreeViewCommandHelp.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
            WindowStartupLocation="CenterScreen"
            Title="MainWindow" Height="350" Width="525">
    
        <Grid>
            <TreeView Name="MyTreeView">
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="MouseDoubleClick"
						            SourceObject="{Binding ElementName=MyTreeView}">
                        <i:InvokeCommandAction Command="{Binding Path=TestCommand}" />
                    </i:EventTrigger>
                </i:Interaction.Triggers>
                <TreeViewItem Header="North America">
                    <TreeViewItem Header="USA" />
                    <TreeViewItem Header="Canada" />
                    <TreeViewItem Header="Mexico" />
                </TreeViewItem>
            
                <TreeViewItem Header="South America">
                    <TreeViewItem Header="Argentina" />
                    <TreeViewItem Header="Brazil" />
                    <TreeViewItem Header="Uruguay" />
                </TreeViewItem>
            </TreeView>
        
            <Button Width="110"
                    Height="25" 
                    Content="Change command"
                    Command="{Binding Path=TestCommand}" />
        </Grid>
    </Window>
Code-behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private ICommand _testCommand = null;
        public ICommand TestCommand
        {
            get
            {
                if (_testCommand == null)
                {
                    _testCommand = new RelayCommand(param => this.Test(), null);
                }
                return _testCommand;
            }
        }
        private void Test()
        {
            MessageBox.Show("Test command...");
        }
    }
