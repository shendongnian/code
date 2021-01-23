    public partial class MainWindow : Window
    {
        public Point Position
        {
            get { return (Point)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(Point), typeof(MainWindow), new PropertyMetadata(new Point()));
        
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Up:
                    if (this.Position.Y <= 0) { break; }
                    this.Position = new Point(this.Position.X, this.Position.Y - 1); break;
                case Key.Down:
                    if (this.Position.Y >= this.PART_Grid.RowDefinitions.Count - 1) { break; }
                    this.Position = new Point(this.Position.X, this.Position.Y + 1); break;
                case Key.Left:
                    if (this.Position.X <= 0) { break; }
                    this.Position = new Point(this.Position.X - 1, this.Position.Y); break;
                case Key.Right:
                    if (this.Position.X >= this.PART_Grid.ColumnDefinitions.Count - 1) { break; }
                    this.Position = new Point(this.Position.X + 1, this.Position.Y); break;
            }
            base.OnKeyDown(e);
        }
        protected override void OnInitialized(EventArgs e) 
        { 
            this.Position = new Point(8, 9); 
            // set the position 
            base.OnInitialized(e); 
        }
    }
