        public partial class MainForm : Form
        {
           engine connEngine = new engine();
    
           public MainForm()
           {
              InitializeComponent();
    
              connEngine = new engine(this);
           }
    
    ...
