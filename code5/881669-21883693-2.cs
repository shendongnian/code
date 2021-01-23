    public partial class Form1 : Form
    {
        int maxNo = 4;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged+=AllCombobox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += AllCombobox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += AllCombobox_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged += AllCombobox_SelectedIndexChanged;
        }
        private void AllCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearPreceding((ComboBox)sender);
        }
        
        void clearPreceding(ComboBox cmbBox)
        {
            int cmbBoxNo = Convert.ToInt32(cmbBox.Name.Substring(cmbBox.Name.Length - 1));
            for (int i = cmbBoxNo; i <= maxNo; i++)
            {
                ((ComboBox)this.Controls.Find("comboBox" + i, true)[0]).Text = "";
            }
        }
    }
