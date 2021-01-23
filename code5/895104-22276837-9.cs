    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e){
            // create an instance of Form2
            var f2 = new Form2();
            // add an event listener to SaveClicked event -which we have declared it in Form2
            f2.SaveClicked += f2_SaveClicked;
            f2.Show();
            // or: f2.ShowDialog();
        }
        void f2_SaveClicked(object obj) {
            // get data and use it here...
            // any data which you pass in Form2.OnSaveClicked method, will be accessible here
        }
    }
