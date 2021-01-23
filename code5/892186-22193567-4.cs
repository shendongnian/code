    <Window x:Class="WpfApplication1.View2"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="View2" Height="300" Width="300"
            Background="{StaticResource {x:Static SystemColors.ControlBrushKey}}"
            xmlns:local="clr-namespace:WpfApplication1"
            >
        <Window.DataContext>
            <local:MyViewModel />
        </Window.DataContext>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
                <RowDefinition Height="Auto" />
                <RowDefinition Height="Auto" />
            </Grid.RowDefinitions>
            <TextBox Text="{Binding MyText, UpdateSourceTrigger=PropertyChanged}" />
            <Slider Value="{Binding MyInt1, UpdateSourceTrigger=PropertyChanged}"  Grid.Row="1" />
        </Grid>
    </Window>
    using System.Windows;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for View2.xaml
        /// </summary>
        public partial class View2 : Window
        {
            public View2()
            {
                InitializeComponent();
            }
            public View2(MyViewModel viewModel)
                : this()
            {
                this.DataContext = viewModel;
            }
        }
    }
