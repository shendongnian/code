    public class PhoneApplicationPage : Page
    {
        public static readonly DependencyProperty ApplicationBarProperty;
        public static readonly DependencyProperty OrientationProperty;
        public static readonly DependencyProperty SupportedOrientationsProperty;
        public PhoneApplicationPage();
        public IApplicationBar ApplicationBar { get; set; }
        public PageOrientation Orientation { get; set; }
        ....
    }
