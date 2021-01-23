        public partial class MainForm : Form
        {
           private engine connEngine = null;
    
           public MainForm()
           {
              InitializeComponent();
    
              connEngine = new engine(this);
           }
    
    ...
