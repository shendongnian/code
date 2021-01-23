    public partial class CodeBehindChart : UserControl
    {
        public CodeBehindChart()
        {
            InitializeComponent();
            Respond();
        }
        private async void Respond()
        {
            await Task.Delay(2000);
            Random r = new Random();
            while (true)
            {
                this.LayoutRoot.Children.Clear();
                
                for (int i = 0; i < 100; i++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.SetValue(Canvas.LeftProperty, r.NextDouble() * this.LayoutRoot.ActualWidth);
                    rectangle.SetValue(Canvas.TopProperty, r.NextDouble() * this.LayoutRoot.ActualHeight);
                    rectangle.Width = 2;
                    rectangle.Height = 2;
                    rectangle.Fill = Brushes.Black;
                    this.LayoutRoot.Children.Add(rectangle);
                }
                await Task.Delay(500);
            }
        }
    }
