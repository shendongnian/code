    public class YourForm : Form
    {
        public YourForm()
        {
            InitializeComponent();
            textBox1.TextChanged += (s,a) => autoCheckChkBoxes(thecheckbox, textBox1);
            textBox2.TextChanged += (s,a) => autoCheckChkBoxes(theNextCheckbox, textBox2);
            // etc...
        }
        ...
    }
