      <Application.Resources>
        <DataTemplate DataType="{x:Type vm:ViewModel}">
            <DockPanel>
                <TextBox Text="{Binding Path=Name,UpdateSourceTrigger=PropertyChanged}">
                </TextBox>
            </DockPanel>
        </DataTemplate>
        <Style TargetType="{x:Type Rectangle}" />
    </Application.Resources>
     class ViewModel : INotifyPropertyChanged
    {
        private string myVar;
        public string Name
        {
            get { return myVar; }
            set
            {
                if (value != myVar)
                {
                    myVar = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
     public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModel oVM = new ViewModel { Name = "Loki" };
            MainWindow oVW = new MainWindow();
            oVW.DataContext = oVM;
            oVW.ShowDialog();
        }
    }
    <Window x:Class="SQ15Mar2015_Learning.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:vm="clr-namespace:SQ15Mar2015_Learning"
        Title="MainWindow" Height="350" Width="525" >
    <Grid>
        <ContentControl Content="{Binding }" />
    </Grid>
