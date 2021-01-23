    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String value1 = File.ReadAllText(textBox1.Text);
            foreach (string line in value1.Split('\n'))
            {
                form2.listBox1.Items.Add(line);
            }
        }
    }
