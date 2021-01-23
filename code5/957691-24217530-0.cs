    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //column 1 (normal textColumn):
            dataGridView1.Columns.Add("col1", "Column1");
            //column 2 (comboBox):
            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            comboCol.Name = "cmbColumn";
            comboCol.HeaderText = "combobox column";
            dataGridView1.Columns.Add(comboCol);
            for (int i = 0; i &lt; 10; i++)
            {
                string text = "item " + i;
                int[] data = { 1 * i, 2 * i, 3 * i };
                CreateCustomComboBoxDataSouce(i, text, data);
            }
        }
        private void CreateCustomComboBoxDataSouce(int row, string texst, int[] data) 
        //row   index        ,and two parameters
        {
            dataGridView1.Rows.Add(texst);
            DataGridViewComboBoxCell comboCell = dataGridView1[1, row] 
            as  DataGridViewComboBoxCell;
            comboCell.DataSource = new BindingSource(data, null);
        }
    }
