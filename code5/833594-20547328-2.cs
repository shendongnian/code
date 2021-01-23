    public partial class Form1 : Form
    {
        public class A
        {
            public string B;
            public int C;
            public override string ToString()
            {
                return B;
            }
        }
        A[] _a = new A[] { new A() { B = "1", C = 111 }, new A() { B = "2", C = 222 }, new A() { B = "3", C = 333 } };
        public Form1()
        {
            InitializeComponent();
            foreach (A item in _a)
                comboBox1.Items.Add(item);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var a = comboBox1.Items[comboBox1.SelectedIndex] as A;
            if (a != null)
                MessageBox.Show(string.Format("{0} {1}", a.B, a.C));
        }
    }
