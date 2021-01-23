    public partial class FormRecord : Form
    {
        Controller controller;
        public FormRecord()
        {
            InitializeComponent();
            controller = new Controller();
        }
        public void UpdateGUI(Frame frame)
        {
             Frame frame = controller.frame();
            //get information from captured frame 
            //update the GUI (specifically labels)
            customLabel0.Text = someValueFromFrame.ToString();
        }
