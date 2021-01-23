    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:sys="clr-namespace:System;assembly=mscorlib"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <ComboBox VerticalAlignment="Center" Text="3"  SelectedItem="{Binding SetWidth}" MinHeight="20">
                <sys:String >1</sys:String>
                <sys:String >2</sys:String>
                <sys:String >3</sys:String>
                <sys:String >4</sys:String>
                
                </ComboBox>
    
        </Grid>
    </Window>
     public partial class MainWindow : Window 
        {
            private string _setWidth;
            public string SetWidth
            {
                get
                {
                    return _setWidth;
                }
                set
                {
                    if ((value == null) || (_setWidth == value))
                        return;
    
                    _setWidth = value;
                    RaisePropertyChanged("SetWidth");
                }
            }       
            public MainWindow()
            {
                
    
                InitializeComponent();
                SetWidth = "3";
                this.DataContext = this;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
