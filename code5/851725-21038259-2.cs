    public partial class Form2 : Form
    {
        public Form1 f1;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (f1 != null)
            {
                foreach (ListViewItem dr in f1.DataVisualizationList.SelectedItems)
                {
                    
                }
            }
        }
    }
