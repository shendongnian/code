    public partial class Options_Form : Form
    {
        public Options_Form()
        {
            InitializeComponent();
        }
        bool[] selecteditemsindex_list;
        private void Options_Load(object sender, EventArgs e)
        {
            AceMP_Class cl = new AceMP_Class();
            listBox1.Items.AddRange(cl.SupportedFiles_stringarray());
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.Size = listBox1.PreferredSize;
            selecteditemsindex_list = new bool[listBox1.Items.Count];
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedIndex = listBox1.SelectedIndex;
            selecteditemsindex_list[selectedIndex] = !selecteditemsindex_list[selectedIndex];
            for (int i = 0; i < selecteditemsindex_list.Count(); i++)
            {
                listBox1.SetSelected(i, selecteditemsindex_list[i]);
            }
        }
    }
