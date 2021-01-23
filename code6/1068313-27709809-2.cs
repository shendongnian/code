       <UserControl x:Class="WpfApplication1.MyControl"
                     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                     xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
                     xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
                     mc:Ignorable="d" 
                     d:DesignHeight="300" d:DesignWidth="300" x:Name="this">
            <Grid Background="Red" PreviewMouseDown="Grid_PreviewMouseDown">
                <TextBlock Text="{Binding ElementName=this, Path=Number}" FontWeight="Bold" />
            </Grid>
        </UserControl>
    
    **MyControl.xaml.cs**
    
    public partial class MyControl : UserControl
        {
            public MyControl()
            {
                InitializeComponent();
            }
    
            public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(int), typeof(MyControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
            public int Number
            {
                get { return (int)GetValue(NumberProperty); }
                set { SetValue(NumberProperty, value); }
            }
    
            private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                e.Handled = true;
                this.Number = 1000;
            }
    
        }
