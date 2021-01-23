    <Window x:Class="WpfApplication1.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="WPF" Height="200" Width="300"
        Loaded="Window_Loaded">
    
        <Window.Resources>
            <DataTemplate x:Key="ListItemTemplate">
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding}" VerticalAlignment="Center"/>
                </StackPanel>
            </DataTemplate>
        </Window.Resources>
        <StackPanel>
            <ListBox x:Name="listBox" ItemTemplate= "{StaticResource ListItemTemplate}"/>
        </StackPanel>
    </Window>
    
    //File:Window.xaml.cs
    
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace WpfApplication1
    {
        public partial class Window1 : Window
        {
            private ObservableCollection<string> numberDescriptions;
    
            public Window1()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                numberDescriptions = new ObservableCollection<string>();
    
                listBox.ItemsSource = numberDescriptions;
    
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background,new LoadNumberDelegate(LoadNumber), 1);
            }
            private delegate void LoadNumberDelegate(int number);
    
            private void LoadNumber(int number)
            {
                numberDescriptions.Add("Number " + number.ToString());
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background,new LoadNumberDelegate(LoadNumber), ++number);
            }
        }
    }
