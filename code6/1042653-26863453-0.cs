    public partial class MainWindow : Window
    {
        public MyPoint myPoint = new MyPoint(100, 200);
        public MainWindow()
        {
            InitializeComponent();
            TextBox X1 = new TextBox();
            TextBox Y1 = new TextBox();
            X1.Margin = new Thickness(0, 0, 20, 20);
            Y1.Margin = new Thickness(0, 0, 100, 100);
            X1.Width = 100;
            Y1.Width = 100;
            X1.Height = 200;
            Y1.Height = 200;
            X1.DataContext = myPoint;
            Y1.DataContext = myPoint;
            System.Windows.Data.Binding BindingX = new System.Windows.Data.Binding("X");
            System.Windows.Data.Binding BindingY = new System.Windows.Data.Binding("Y");
            BindingX.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingY.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingX.Mode = System.Windows.Data.BindingMode.TwoWay;
            BindingY.Mode = System.Windows.Data.BindingMode.TwoWay;
            BindingX.Source = myPoint;
            BindingY.Source = myPoint;
            X1.SetBinding(TextBox.TextProperty, BindingX);
            Y1.SetBinding(TextBox.TextProperty, BindingY);
            this.MainGrid.Children.Add(Y1);
            
            
            this.MainGrid.Children.Add(X1);
            X1.Text = "1";
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(myPoint.X + "=X |  Y=" + myPoint.Y);
            //myPoint.Y = 1123;
            //myPoint.X = 3123;
        }
        
    }
    public class MyPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double _x;
        private double _y;
        public double X { get { return _x; } set { _x = value; NotifyPropertyChanged("X"); } }
        public double Y { get { return _y; } set { _y = value; NotifyPropertyChanged("Y"); } }
        public MyPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
