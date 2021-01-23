        DataGridView DGV1 = new DataGridView();
        DataGridView DGV2 = new DataGridView();
        DataGridView DGV3 = new DataGridView();
        DataTable DT = new DataTable();
        //..
        BindingSource BS1 = new BindingSource();
        BindingSource BS2 = new BindingSource();
        BindingSource BS3 = new BindingSource();
        BS1.DataSource = DT;
        BS2.DataSource = DT;
        BS3.DataSource = DT;
        DGV1.DataSource = BS1;
        DGV2.DataSource = BS2;
        DGV3.DataSource = BS3;
        // now set the record pointer:
        BS1.Position = 3;        
        BS2.Position = 0;        
        BS3.Position = BS3.Count - 1;        
        // or set filters:
        BS2.Filter = "somecodition";
