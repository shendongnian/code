     BindingSource SBind = new BindingSource();
     SBind.DataSource = dtSourceData;
     ADGView1.AutoGenerateColumns = true;  //must be "true" here
     ADGView1.DataSource = dtSourceData;
     ADGView1.Columns.Clear();
     ADGView1.DataSource = SBind;
     
     //set DGV's column names and headings from the Datatable properties
     for (int i = 0; i < ADGView1.Columns.Count; i++)
     {
           ADGView1.Columns[i].DataPropertyName = dtSourceData.Columns[i].ColumnName;
           ADGView1.Columns[i].HeaderText = dtSourceData.Columns[i].Caption;
     }
     ADGView1.Enabled = true;
     ADGView1.Refresh();
