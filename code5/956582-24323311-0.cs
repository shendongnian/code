    public Form3()
        {
            InitializeComponent();
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
        }
        bool flag = false;
        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtCell = e.Control as TextBox;
            if (txtCell != null) 
            {
                txtCell.PreviewKeyDown -= new PreviewKeyDownEventHandler(txtCell_PreviewKeyDown);
                txtCell.PreviewKeyDown += new PreviewKeyDownEventHandler(txtCell_PreviewKeyDown);
                txtCell.KeyDown -= new KeyEventHandler(txtCell_KeyDown);
                txtCell.KeyDown += new KeyEventHandler(txtCell_KeyDown);
            }
        }
        void txtCell_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox tCell = (TextBox)sender;
                if (dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    if (e.KeyCode == Keys.Return)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void txtCell_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TextBox tCell = (TextBox)sender;
            if (!flag)
            {
                flag = true;
                if (e.KeyCode == Keys.Return)
                {
                    //e.SuppressKeyPress = true;
                    int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                    int iRow = dataGridView1.CurrentCell.RowIndex;
                    if (iColumn == 5)
                    {
                        dataGridView1.Focus();
                        dataGridView1.CurrentCell = dataGridView1[2, iRow];
                        dataGridView1.CurrentCell.Value = "123";
                        iColumn = 0;
                        iRow = 0;
                        flag = false;
                        return;
                    }
                    if (iColumn == 2)
                    {
                        dataGridView1.Focus();
                        dataGridView1.CurrentCell = dataGridView1[3, iRow];
                        dataGridView1.CurrentCell.Value = "123";
                        iColumn = 0;
                        iRow = 0;
                        flag = false;
                        return;
                    }
                    if (iColumn == 3)
                    {
                        dataGridView1.Focus();
                        dataGridView1.CurrentCell = dataGridView1[5, iRow + 1];
                        dataGridView1.CurrentCell.Value = "123";
                        iColumn = 0;
                        iRow = 0;
                        flag = false;
                        return;
                    }
                    flag = false;
                    return;
                }
                flag = false;
                return;
            }
            flag = false;
            return;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.Focus();
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[5];
        }
