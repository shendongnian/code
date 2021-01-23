    public class CustomMsgBox : Form {
        private string _msg = string.Empty;
        public CustomMsgBox(string msg) {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Button btn = new Button()
            btn.Text = "&Close";
            btn.Width = 80;
            this.Controls.Add(btn);
            btn.Location = new Point(this.Width - (btn.Width + 50), this.Height - (btn.Height + 50));
            this.CancelButton = btn;
            this.AcceptButton = btn;
            btn.Click += new EventHandler(this.btn_Clicked);
        }
    
        private void btn_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
    public class MyMessageBox
    {
        public static DialogResult Show(string _message)
        {
            return Show(_message, string.Empty);
        }
        public static DialogResult Show(string _message, string _title)
        {
            CustomMsgBox msg =new CustomMsgBox(_message);
            msg.Text = _title;
            rturn msg.ShowDialog();
        }
    }
    
    
    CALL:
    
    MyMessageBox.Show("This is a sample Text 1", "Hello World");
    MyMessageBox.Show("This is a sample Text 2");
