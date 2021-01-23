    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
            this.Location = Parent_Form.GetLocation();
            this.FormClosing += Notification_FormClosing;
        }
        private void button1_Click(object sender, EventArgs e) { this.Close(); }
        private void Notification_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parent_Form.activeNotifications.Remove(this);
            Parent_Form.SortNotifications();
        }
    }
