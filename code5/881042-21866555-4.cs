        public partial class MainForm : Form
        {
           private engine connEngine = new engine();
    
           public MainForm()
           {
              InitializeComponent();
    
              connEngine = new engine(this);
           }
    
    ...
