    DataTable dtPlodiny;
    using(SqlConnection sqlConn = new SqlConnection(conn))//conn - your connection string
    {
        string sqlQuery = @"SELECT ID, Description FROM PLODINY"; //better practice use only fields you need
        using(SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtPlodiny);
        }
    }
    cbColumn = new DataGridViewComboBoxColumn();
    cbColumn.Name = "POLOZKAcb" 
    cbColumn.DataSource = dtPlodiny; //Changed with DataTable
    //add next two rows
    cbColumn.DisplayMember = "Description" //property from .Datasource you want to show for user
    cbColumn.ValueMember = "ID" //property from .Datasource you want use as Value - reference to DataPropertyName
    cbColumn.DropDownWidth = 100;
    dataGridView1.Columns.Add(cbColumn);
    cbColumn.DisplayIndex = 3;
    cbColumn.HeaderText = "Položka";
    cbColumn.DataPropertyName = "POLOZKAcb";
