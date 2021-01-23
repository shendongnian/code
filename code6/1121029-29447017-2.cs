        // assume a few DataGridViews..: 
        DataGridView DGV1 = new DataGridView();
        DataGridView DGV2 = new DataGridView();
        DataGridView DGV3 = new DataGridView();
        // and a common DataTable:
        DataTable DT = new DataTable();
        //..
        // we need a separate BindingSource for each DGV:
        BindingSource BS1 = new BindingSource();
        BindingSource BS2 = new BindingSource();
        BindingSource BS3 = new BindingSource();
        // each is bound to the DataTable
        BS1.DataSource = DT;
        BS2.DataSource = DT;
        BS3.DataSource = DT;
        // now we set them to be the DatSource of the DGVs:
        DGV1.DataSource = BS1;
        DGV2.DataSource = BS2;
        DGV3.DataSource = BS3;
        // now we can set the record pointers separately:
        BS1.Position = 3;        
        BS2.Position = 0;        
        BS3.Position = BS3.Count - 1;   
     
        // or set filters:
        BS2.Filter = "someCondition";  
   
        // or set sorts:
        BS3.Filter = "someSort";
