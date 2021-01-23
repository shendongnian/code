XAML
    <Window x:Class="DisableComboBoxButton.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525"
        Loaded="Window_Loaded">
    
        <StackPanel>
            <ComboBox Name="comboBox"
                      Width="100" 
                      Height="25"
                      SelectedIndex="0">
                <ComboBoxItem>Test1</ComboBoxItem>
                <ComboBoxItem>Test2</ComboBoxItem>
                <ComboBoxItem>Test3</ComboBoxItem>
            </ComboBox>
            <ComboBox Name="AllComboBoxDisabled"
                      Width="100" 
                      Height="25"
                      IsEnabled="False"
                      SelectedIndex="0">
                <ComboBoxItem>Test1</ComboBoxItem>
                <ComboBoxItem>Test2</ComboBoxItem>
                <ComboBoxItem>Test3</ComboBoxItem>
            </ComboBox>
        </StackPanel>
    </Window>
Code-behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ToggleButton dropDownButton = GetFirstChildOfType<ToggleButton>(comboBox);
            dropDownButton.IsEnabled = false;
        }
        public static T GetFirstChildOfType<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            if (dependencyObject == null)
            {
                return null;
            }
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = VisualTreeHelper.GetChild(dependencyObject, i);
                var result = (child as T) ?? GetFirstChildOfType<T>(child);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
Output
