    public partial abstract class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void SetTextBox(string message)
        {
            Textbox_Status.Text = message;
        }
        protected abstract void DeviceCheck();
        private void timer1_Tick(object sender, EventArgs e)
        {
            DeviceCheck();
        }
    }
    public class Device : MainPage
    {
        public void DeviceCheck()
        { 
            //Do other stuff here
            SetTextBox("Some text");
        }
    }
