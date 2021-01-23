    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace WpfTestBench
    {
        public partial class PanelSample
        {
            public PanelSample()
            {
                InitializeComponent();
    
                for (var i = 0; i < 5; i++)
                {
                    MyPanel.Children.Add(new Rectangle
                    {
                        Width = 100,
                        Height = 20,
                        StrokeThickness = 1,
                        Stroke = new SolidColorBrush(Colors.Black),
                        Margin = new Thickness(5)
                    });
                }
            }
        }
    }
