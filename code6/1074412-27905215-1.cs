    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataGridView dgv = new DataGridView();
    
                // add some columns and rows
                for (int i = 0; i < 10; i++)
                {
                    DataGridViewCell c = new DataGridViewHeaderCell();
                    dgv.Columns.Add("Column" + i, Convert.ToString(i));
                }
    
                for (int i = 0; i < 10; i++)
                {
                    dgv.Rows.Add(new DataGridViewRow());
                }
    
                //create a new DataGridViewComboBoxCell and give it a datasource
                var DGVComboBox = new DataGridViewComboBoxCell();
    
                DGVComboBox.DataSource = new List<string> {"one", "two", "three"};
                DGVComboBox.Value = "one"; // set default value of the combobox
    
                // add it to cell[4,4] of the DataGridView
                dgv[4, 4] = DGVComboBox;
    
                // add the DataGridView to the form
                this.Controls.Add(dgv);
            }
        }
