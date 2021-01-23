    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
    		Instance = this;
        }
        
    	public static Form3 Instance { get; private set; }
    	
    	public void WebLyrics(string url)
    	{
            webBrowser1.Navigate(url);
        }
    }
