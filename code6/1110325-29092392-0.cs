    public partial class Form1 : Form
    {
        private bool ignoreEvents = false;
        public Form1()
        {
            InitializeComponent();
            //set this handler to the events of all 3 checkboxes
            checkBox1.CheckedChanged += radioCheckboxes_CheckedChanged;
            checkBox2.CheckedChanged += radioCheckboxes_CheckedChanged;
            checkBox3.CheckedChanged += radioCheckboxes_CheckedChanged;
        }
        private void radioCheckboxes_CheckedChanged(object sender, EventArgs e)
        {
            if (!ignoreEvents)
            {
                ignoreEvents = true; // otherwise the other checkboxes would react when i set the state programmatically
                CheckBox current = sender as CheckBox;
                if (current == checkBox1)
                {
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (current == checkBox2)
                {
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                }
                else
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                }
                ignoreEvents = false;
            }
        }
    }
