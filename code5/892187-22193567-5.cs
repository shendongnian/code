    <Window x:Class="WpfApplication1.View3"
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
            <TextBox Text="{Binding MyInt1, UpdateSourceTrigger=PropertyChanged}" Grid.Row="1" />
            <TextBox Text="{Binding MyInt2, UpdateSourceTrigger=PropertyChanged}" Grid.Row="2" />
        
        </Grid>
        
    </Window>
    using System.Windows;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for View3.xaml
        /// </summary>
        public partial class View3 : Window
        {
            public View3()
            {
                InitializeComponent();
            }
            public View3(MyViewModel viewModel)
                : this()
            {
                this.DataContext = viewModel;
            }
        }
    }
