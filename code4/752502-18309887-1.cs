    public partial class MainWindow : Window
    {
    
    	bool toggle;
    
        public MainWindow()
        {
            InitializeComponent();
            MainWindow.KeyDown += (sender, eventArgs) => { if (eventArgs.Key == Key.F7) toggle = !toggle; };
        }
    
    	private void MainWindow_KeyDown(object sender, EventArgs e)
    	{
    
    		if (toggle)
    		{
    			//System.Windows.MessageBox.Show("go to second position...!");
    		}
    		else
    		{
    			//System.Windows.MessageBox.Show("go to first position...!");
    		}
    	}
    }
