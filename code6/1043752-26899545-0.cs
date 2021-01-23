    namespace MyApplication
    {
        public partial class MainPage : Form
        {
            public MainPage()
            {
                InitializeComponent();
            }
    
            public static void SetTextBox(string Message)
            {
                Textbox_Status.Text = Message;
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                string result = Device.DeviceCheck();
                SetTextBox(result);
            }
        }
    
        public class Device : MainPage
        {
            public string DeviceCheck()
            { 
                //Do other stuff here
                return("Some text");
            }
        }
    }
