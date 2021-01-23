    public partial class UserControl1 : UserControl {
        public event EventHandler EnterPressed;
        public UserControl1() {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown;
        }
        protected void OnEnterPressed(EventArgs e) {
            var handler = this.EnterPressed;
            if (handler != null) handler(this, e);
        }
        void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                OnEnterPressed(EventArgs.Empty);
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
