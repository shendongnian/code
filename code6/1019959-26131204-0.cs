        namespace WpfApplication65
    {
        public abstract class NotifyBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void NotifyPropertyChanged(string property)
            {
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
        }
    
        public abstract class DataBase : NotifyBase
        {
            bool m_showDetailed;
            public bool ShowDetailed
            {
                get { return m_showDetailed; }
                set
                {
                    m_showDetailed = value;
                    NotifyPropertyChanged("ShowDetailed");
                }
            }
        }
    
        public class DogData : DataBase { }
        public class CatData : DataBase { }
    
        public partial class MainWindow : Window
        {
            public List<DataBase> Items { get; private set; }
    
            public MainWindow()
            {
                Items = new List<DataBase>() { new DogData(), new CatData(), new DogData() };
    
                DataContext = this;
                InitializeComponent();
            }
        }
    }
        <Window x:Class="WpfApplication65.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:l="clr-namespace:WpfApplication65"
            Title="MainWindow"
            WindowStartupLocation="CenterScreen">
        
        <Window.Resources>
            <DataTemplate DataType="{x:Type l:CatData}">
                <DataTemplate.Resources>
                    <DataTemplate x:Key="basic">
                        <TextBlock Text="This is the basic cat view" />
                    </DataTemplate>
    
                    <DataTemplate x:Key="detailed">
                        <TextBlock Text="This is the detailed cat view" />
                    </DataTemplate>
                </DataTemplate.Resources>
    
                <Border BorderThickness="1"
                        BorderBrush="Red"
                        Margin="2"
                        Padding="2">
                    <StackPanel>
                        <ContentPresenter Name="PART_Presenter"
                                          ContentTemplate="{StaticResource basic}" />
                        <CheckBox Content="Show Details"
                                  IsChecked="{Binding ShowDetailed}" />
                    </StackPanel>
                </Border>
    
                <DataTemplate.Triggers>
                    <DataTrigger Binding="{Binding ShowDetailed}"
                                 Value="True">
                        <Setter TargetName="PART_Presenter"
                                Property="ContentTemplate"
                                Value="{StaticResource detailed}" />
                    </DataTrigger>
                </DataTemplate.Triggers>
            </DataTemplate>
    
            <DataTemplate DataType="{x:Type l:DogData}">
                <DataTemplate.Resources>
                    <DataTemplate x:Key="basic">
                        <TextBlock Text="This is the basic dog view" />
                    </DataTemplate>
    
                    <DataTemplate x:Key="detailed">
                        <TextBlock Text="This is the detailed dog view" />
                    </DataTemplate>
                </DataTemplate.Resources>
    
                <Border BorderThickness="1"
                        BorderBrush="Blue"
                        Margin="2"
                        Padding="2">
                    <StackPanel>
                        <ContentPresenter Name="PART_Presenter"
                                          ContentTemplate="{StaticResource basic}" />
                        <CheckBox Content="Show Details"
                                  IsChecked="{Binding ShowDetailed}" />
                    </StackPanel>
                </Border>
    
                <DataTemplate.Triggers>
                    <DataTrigger Binding="{Binding ShowDetailed}"
                                 Value="True">
                        <Setter TargetName="PART_Presenter"
                                Property="ContentTemplate"
                                Value="{StaticResource detailed}" />
                    </DataTrigger>
                </DataTemplate.Triggers>
            </DataTemplate>
        </Window.Resources>
    
        <ListBox ItemsSource="{Binding Items}" />
    </Window>
