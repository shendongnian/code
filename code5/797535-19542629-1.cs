    public partial class Form2 : Form
    {
        //Declare your event
        public event EventHandler updateEvent;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //If the event is registered fire it, otherwise do nothing
            if (updateEvent != null)
            {
                //fire the event and give our custom event args some text
                updateEvent(sender, e);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Another way to close the form, beside clicking the red "X"
            Close();
        }
    }
