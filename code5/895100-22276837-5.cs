    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e){
            var f2 = new Form2();
            f2.SaveClicked += f2_SaveClicked;
            f2.Show();
            // or: f2.ShowDialog();
        }
        void f2_SaveClicked(object obj) {
            // get data and use it here...
        }
    }
