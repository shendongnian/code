    public sealed partial class MainPage : Page
    {
        public static MainPage Current;        
        public MainPage()
        {
            this.InitializeComponent();            
            // This is a static public property that allows downstream pages to get a handle to the MainPage instance
            // in order to call methods that are in this class.
            Current = this;            
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
    }
