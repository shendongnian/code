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
       protected event EventHandler TimerTick;
        private void timer1_Tick(object sender, EventArgs e)
        {
            EventHandler handler = TimerTick;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
    public class Device : MainPage
    {
        public Device()
        {
            TimerTick += (sender, e) => DeviceCheck();
        }
        public void DeviceCheck()
        { 
            //Do other stuff here
            SetTextBox("Some text");
        }
    }
