    public partial class MainPage : PhoneApplicationPage
    {
        DispatcherTimer dt;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // create our dispatch timer
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dt_Tick;
        }
        // start the timer only when the page has loaded
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Start();
        }
        /// Every tick, generate a random number from 1 to 9.
        /// Use this number to find the Ellipse
        /// Set the Storyboard to this found Ellipse
        /// Start the Animation
        void dt_Tick(object sender, EventArgs e)
        {                       
            // generate a random number
            Random rmd = new Random();
            int random_int = rmd.Next(1, 9);
            Storyboard sb = (Storyboard)Application.Current.Resources["mystory1"];              // get the storyboard from Resources
            ColorAnimation ca = (ColorAnimation) sb.Children[0];                                // get the color animation
            sb.Stop();                                                                          // stop the storyboard to change the target name
            object myobject = this.FindName("El" + random_int.ToString());                      // setup the name based off the random number
            Storyboard.SetTarget(ca, (DependencyObject) myobject);                              // set the new target
            sb.Begin();                                                                         // start the animation
        }
    }
