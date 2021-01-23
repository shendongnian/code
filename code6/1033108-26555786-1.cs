    public partial class Form1 : Form
    {
        public Form1(string listview_val)
        {
            InitializeComponent();
            this.listView1.Items.Add(listview_val);
        }
    }
