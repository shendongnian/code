    public partial class Form1 : Form
    {
        private ListBox CurrentListBox = null;
        public Form1()
        {
            InitializeComponent();
            ListBox1.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
            ListBox2.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
            ListBox3.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
        }
        void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentListBox = (ListBox)sender;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (CurrentListBox != null && CurrentListBox.SelectedIndex != -1)
            {
                CurrentListBox.Items.Remove(CurrentListBox.SelectedItem);
            }
        }
    }
