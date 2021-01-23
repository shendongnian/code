    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            int highestPrice = 65;
            List<int> vals = new List<int>() { 10, 20, 30, 40, 50 };
            int min = vals.Min();
            int max = vals.Max();
            max = highestPrice > max ? highestPrice : max;
            double range = max - min;
    
            // Draw max in red
            Color c = new Color() { ScA = 1, ScR = 1, ScG = 0, ScB = 0 };
            // y = 0 is at the top of the canvas
            var line = new Line() { X1 = 0, Y1 = 0, X2 = canvas.Width, Y2 = 0, Stroke = new SolidColorBrush(c), StrokeThickness = 2.0 };
            canvas.Children.Add(line);
            // Add txt so we can visualize better
            var txt = new TextBlock() { Text = max.ToString() };
            Canvas.SetLeft(txt, canvas.Width / 2);
            Canvas.SetTop(txt, 0 - 9);
            canvas.Children.Add(txt);
    
            foreach (int val in vals)
            {
                double percent = 1.0 - ((val - min)/range); // 0 is at the top, so invert it by doing 1.0 - xxx
                double y = percent*canvas.Height;
                // Draw line in a shade of blue/green
                c = new Color() { ScA = 1, ScR = 0, ScG = 0.5f, ScB = (float)percent };
                line = new Line() { X1 = 0, Y1 = y, X2 = canvas.Width, Y2 = y, Stroke = new SolidColorBrush(c), StrokeThickness = 2.0 };
                canvas.Children.Add(line);
    
                // Add txt so we can visualize better
                txt = new TextBlock() { Text = val.ToString() };
                Canvas.SetLeft(txt, canvas.Width / 2);
                Canvas.SetTop(txt, y - 9);
                canvas.Children.Add(txt);
            }
        }
    }
