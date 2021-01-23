    public partial class obj : Form
    {
        public static string text; //This is a variable that can be reached from 
        public obj()
        {
            InitializeComponent();
        }
        private void máquinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            machinename open = new machinename();
            open.ShowDialog(); //I put ShowDialog instead of Show
            addItem(); //This method is called when the showed dialog is closed (machinename.cs)
        }
        private void addItem()
        {
            listMachine.Items.Add(text);
        }
    }
