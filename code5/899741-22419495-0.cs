    namespace dgvRowBinding
    {
        public partial class Form1 : Form
        {
            DataTable dt1;
            DataTable dt2;
            bool isDataReady = false;
    
            TreeNode tnOne;
            TreeNode tnTwo;
            TreeNode tnThree;
            TreeNode tnFour;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                tnOne = new TreeNode("Node #1");
                tnOne.Tag = 1;
    
                tnTwo = new TreeNode("Node #2");
                tnTwo.Tag = 2;
    
                tnThree = new TreeNode("Node #3");
                tnThree.Tag = 3;
    
                tnFour = new TreeNode("Node #4");
                tnFour.Tag = 4;
    
                tv.Nodes.Add(tnOne);
                tv.Nodes.Add(tnTwo);
                tv.Nodes.Add(tnThree);
                tv.Nodes.Add(tnFour);
    
                dt1 = new DataTable();
                dt1.Columns.Add(new DataColumn("Name", typeof(string)));
                dt1.Columns.Add(new DataColumn("Descripton", typeof(string)));
    
                dt1.Rows.Add(new object[] { "Grant", "the couch guy" });
                dt1.Rows.Add(new object[] { "Mike", "the pizza guy" });
                dt1.Rows.Add(new object[] { "Lee", "don't cross me guy" });
                dt1.Rows.Add(new object[] { "Adamn", "the number guy" });
                dt1.Rows.Add(new object[] { "Freddy", "I love my pork chops" });
                dt1.Rows.Add(new object[] { "Gus", "Me and my chicken" });
                dt1.Rows.Add(new object[] { "Walt", "i love my blue" });
                dt1.Rows.Add(new object[] { "Saul", "mind you, I'm a lawyer" });
                dt1.Rows.Add(new object[] { "Jessy", "i need to charge my batteries" });
    
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[0].DataPropertyName = dt1.Columns[0].ColumnName;
                dataGridView1.Columns[1].DataPropertyName = dt1.Columns[1].ColumnName;
    
    
                isDataReady = true;
    
                dt2 = new DataTable();
                dt2.Columns.Add(new DataColumn("Name", typeof(string)));
                dt2.Columns.Add(new DataColumn("Description", typeof(string)));
                dt2.Columns[0].ColumnName = dt1.Columns[0].ColumnName;
                dt2.Columns[1].ColumnName = dt1.Columns[1].ColumnName;
    
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns[0].DataPropertyName = dt2.Columns[0].ColumnName;
                dataGridView2.Columns[1].DataPropertyName = dt2.Columns[1].ColumnName;
            }
    
            private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    if (isDataReady)
                    {
                        if (Convert.ToBoolean(dataGridView1[2, e.RowIndex].Value) == true)
                        {
                            DataRow dr1 = ((DataRowView)(dataGridView1.Rows[e.RowIndex].DataBoundItem)).Row;
    
                            dt2.ImportRow(dr1);
    
                        } 
                    }
                }
                catch
                {                
                    throw;
                }
            }
    
            private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
                try
                {
                    if (isDataReady == true)
                    {
                        if (dataGridView1.IsCurrentCellDirty == true)
                        {
                            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                            {
                                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            }
                        }
                    }
                }
                catch
                {
    
                    throw;
                }
            }
        }
    
        struct MyStruct
        {
    
        }
    }
