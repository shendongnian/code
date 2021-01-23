    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public Planets Planet
        {
            get { return (Planets)GetValue(PlanetProperty); }
            set { SetValue(PlanetProperty, value); }
        }
        
        public static readonly DependencyProperty PlanetProperty =
            DependencyProperty.Register("Planet", typeof(Planets), typeof(UserControl1), new UIPropertyMetadata(Planets.Mercury));
  
    }
    public enum Planets
    { 
        Mercury, 
        Venus, 
        Earth,
        Mars
        
    }
