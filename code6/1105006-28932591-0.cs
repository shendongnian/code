    public partial class Form1 : Form
    {
        string Path1 = "MyFile.txt";
        List<TextBox> textBoxes = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();            
        }        
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    textBoxes.Add((TextBox)item);
                }
            }
            string[] lines = File.ReadAllLines(Path1);
            for (int i = 0; i < lines.Length; ++i)
            {
                textBoxes[i].Text = lines[i];
            }         
        }
    }
