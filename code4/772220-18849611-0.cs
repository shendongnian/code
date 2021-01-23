    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
        }
        private void radioButton1_Click(object sender, EventArgs e) {
            MessageBox.Show("RadioButton");
        }
        private void listView1_Click(object sender, EventArgs e) {
            MessageBox.Show("ListView");
        }
        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("Button");
        }
        private void UserControl1_Click(object sender, EventArgs e) {
            MessageBox.Show("UserControl");
        }
    }
