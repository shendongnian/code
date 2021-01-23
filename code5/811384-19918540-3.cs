    public partial class Form1 : Form
    {
        SerialThing mySerialThing;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mySerialThing = new SerialThing();
            mySerialThing.DataReceived += new SerialThing.DataReceivedDelegate(mySerialThing_DataReceived);
        }
        private delegate void DataReceivedDelegate(string data);
        void mySerialThing_DataReceived(string data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DataReceivedDelegate(mySerialThing_DataReceived), new Object[] { data });
            }
            else
            {
                textBox1.Text = data;
            }
        }
    }
