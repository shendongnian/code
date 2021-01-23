      <Application.Resources>
        <DataTemplate DataType="{x:Type vm:ViewModel}">
            <DockPanel>
                <TextBox Text="{Binding Path=Name,UpdateSourceTrigger=PropertyChanged}">
                </TextBox>
            </DockPanel>
        </DataTemplate>
        <Style TargetType="{x:Type Rectangle}" />
    </Application.Resources>
<!---->
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
