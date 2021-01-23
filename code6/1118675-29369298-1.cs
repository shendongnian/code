        public partial class MainWindow : Window
        {
         public MainWindow()
                {
                    InitializeComponent();
                    Line[] lines = new Line[1000];
                    for(int i=0; i<1000;i++)
                    {
                        lines[i] = new Line();
                        lines[i].Stroke = new SolidColorBrush(Colors.Red);
                        lines[i].StrokeThickness = 5;
                        lines[i].X1 = 0;
                        lines[i].X2 = 0;
                        lines[i].Y1 = 30;
                        lines[i].Y2 = 20;
                    }
                    DrawLines(lines);
                }
    
        private void DrawLines(Line[] _lines)
                {
                    foreach (Line _line in _lines)
                    {
                        stackGraphicsArea.Children.Add(_line);
                    }
                }
    }
