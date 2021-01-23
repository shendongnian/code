    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var object1 = new SpecialClass {Text = "First line", Number = 1d};
            var object2 = new SpecialClass { Text = "Second line", Number = 2d};
            listBox1.Items.Add(object1);
            listBox1.Items.Add(object2);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpecialClass o = ((ListBox) sender).SelectedItem as SpecialClass;
            label1.Text = o.Number.ToString();
        }
    }
    public class SpecialClass
    {
        public string Text { get; set; }
        public double Number { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
