    public partial class Form1 : Form
    {
        List<TextBox> textBoxes = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Approach 1: create and add textbox to list
            TextBox createdTextbox = new TextBox();
            textBoxes.Add(createdTextbox);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //use the textboxes from the list
            foreach(TextBox t in textBoxes)
            {
                //do something with t
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Approach 2: use eventhandlers and don't store textbox in a list
            TextBox createdTextbox = new TextBox();
            createdTextbox.TextChanged += createdTextbox_TextChanged;
            listBox1.Items.Add(createdTextbox);
        }
        void createdTextbox_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t == null)
                throw new ArgumentException("sender not of type TextBox", "sender");
            //do something with t
        }
    }
