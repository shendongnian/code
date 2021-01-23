    public partial class BgBoard : Window 
    {
        public static DependencyProperty BarParamsProperty = DependencyProperty.RegisterAttached("BarParams", typeof(string),
              typeof(BgBoard), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None,
              new PropertyChangedCallback(BarParamsPropertyChanged)));
        public static string GetBarParams(Grid Grid) { return Convert.ToString(Grid.GetValue(BarParamsProperty)); }
        public static void SetBarParams(Grid Grid, string Value) { Grid.SetValue(BarParamsProperty, Value); }
        private static void BarParamsPropertyChanged(Object Sender, DependencyPropertyChangedEventArgs e)
    {
            Grid Grid = (Grid)Sender;
            string[] sBarParams = GetBarParams(Grid).Split('/');
            for (int player = (int)Player.Player1; player <= (int)Player.Player2; player++)
            {
                string[] sBarParam = sBarParams[player].Split(',');
                string type = sBarParam[0];
                int size = Convert.ToInt32(sBarParam[1]);
                int column = Convert.ToInt32(sBarParam[2]);
                int row = Convert.ToInt32(sBarParam[3]);
                int columnspan = Convert.ToInt32(sBarParam[4]);
                int rowspan = Convert.ToInt32(sBarParam[5]);
                BgPin pin = new BgPin(type, size);
                Grid.SetColumn(pin, column);
                Grid.SetRow(pin, row);
                Grid.SetColumnSpan(pin, columnspan);
                Grid.SetRowSpan(pin, rowspan);
                pin.Player = (Player)player;
                Grid.Children.Add(pin);
                BgBoard Board = (BgBoard)Grid.Parent;
                Board._Bar[player] = pin;
            }
        }
        private BgPin[] _Bar = new BgPin[2];       
        public BgBoard()
        {
            InitializeComponent();
            _Bar[0].Checkers = 3;
        }
 
