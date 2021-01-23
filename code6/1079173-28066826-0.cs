    public sealed partial class MainPage : Page
        {        
            public static readonly DependencyProperty RotationsProperty = 
                DependencyProperty.Register("Rotations", typeof(ObservableCollection<double>), typeof(MainPage),
                new PropertyMetadata(new ObservableCollection<double>()));       
            
            public ObservableCollection<double> Rotations
            {
                get { return (ObservableCollection<double>)GetValue(RotationsProperty); }
                set { SetValue(RotationsProperty, value); }
            }
    
            private void Op_Click(object sender, RoutedEventArgs e)
            {
                Rotations[0] = 180;
                Rotations[1] = 180;
                Rotations[2] = 320;
            }
    
            public MainPage()
            {
                this.InitializeComponent();
                Rotations.Add(90);
                Rotations.Add(90);
                Rotations.Add(90);
            }
        }
