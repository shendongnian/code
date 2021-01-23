    <Window x:Class="WpfApplication2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Window.Resources>
        <Style x:Key="SomeStyle">
            <Style.Triggers>
                <Trigger Property="CheckBox.IsChecked" Value="True">
                    <Trigger.Setters>
                        <Setter Property="CheckBox.Content" Value="Uncheck all"></Setter>
                    </Trigger.Setters>
                </Trigger>
                <Trigger Property="CheckBox.IsChecked" Value="False">
                    <Trigger.Setters>
                        <Setter Property="CheckBox.Content" Value="Check all"></Setter>
                    </Trigger.Setters>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <CheckBox Grid.Column="1" Grid.Row="0" Margin="200 7 0 0" Name="IsCheckedCheckAll" Style="{StaticResource SomeStyle}"/>
        <CheckBox Name="Exc2" Grid.Column="1" Grid.Row="1" Margin="200 7 0 0" IsChecked="{Binding IsChecked, ElementName=IsCheckedCheckAll, Mode=OneWay}" />
        <CheckBox Name="Exc3" Grid.Column="1" Grid.Row="2" Margin="200 7 0 0" IsChecked="{Binding IsChecked, ElementName=IsCheckedCheckAll, Mode=OneWay}" />
        <Button Grid.Column="1" Grid.Row="3" Content="{Binding IsChecked, ElementName=IsCheckedCheckAll}" Click="ButtonBase_OnClick"></Button>
    </Grid>
</Window>
namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((bool) Exc2.IsChecked).ToString());
        }
    }
}
