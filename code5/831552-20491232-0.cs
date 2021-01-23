    public class MyWindow : Window
    {
 
        public static MyWindow Instance { get; private set;}
        public MyWindow() 
        {
            InitializeComponent();
            // save value
            Instance = this; 
        }
        public static getControl()
        {
            // use value
            if (Instance != null)
                var control = Instance.switchcontrol; 
        }
    }
