    public class Utility
    {
        public static Action<string> SetNotePadValue
        {
            get;
            set;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Utility.SetNotePadValue = (s) =>
            {
                // textBox1 is a control on this form
                this.textBox1.AppendText(s + "\r\n");
            };
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // this will set value in Form1's textBox1
            Utility.SetNotePadValue("Some text");
        }
    }
