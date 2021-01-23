    // Create a custom marker control as follows
    // CustomMarker.xaml:
    <d3:ViewportUIContainer x:Class="MyNamespace.CustomMarker"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:d3="clr-namespace:Microsoft.Research.DynamicDataDisplay.Charts;assembly=DynamicDataDisplay"
                        mc:Ignorable="d" >
       <Grid>
          <TextBlock Name="TxtBlk1" Text="Some Text" />
       </Grid>
    </d3:ViewportUIContainer>
   
    // Marker control code behind CustomMarker.cs
    using System;
    using System.Windows;
    using System.Windows.Media;
    namespace MyNamespace
    {        
        public partial class CustomMarker : Microsoft.Research.DynamicDataDisplay.Charts.ViewportUIContainer 
        {
            public CustomMarker()
            {
                InitializeComponent();
            }
            public CustomMarker(Point position, string text, Color color) : this()
            {          
                Position = position;
                TxtBlk1.Text = text;
                TxtBlk1.Foreground = new SolidColorBrush(color);
            } 
        }
    }
 
    
    //In your mainwindow.cs
    var position = new Point(x value, y value);
    plotter.Children.Add(new CustomMarker(position, "Text", Colors.Black));
