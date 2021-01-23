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
   
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Instance = null; // remove reference, so GC could collect it, but you need to be sure there is only one instance!!
        }
    }
