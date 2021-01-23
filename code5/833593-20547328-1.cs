    class cAuditTaskEntity
    {
        public int A;
        public string B;
        ...
        public cAuditTaksEntity() {}
    }
    // data to fill into a combobox
    cAuditTaskEntity[] data = new cAuditTaksEntity[] {new cAuditTaskEntity(), new cAuditTaksEntity(), new cAuditTaskEntity() ... }
    // fill combobox, we represent data as a string
    for(int i = 0; i < data.Length; i++)
        cmbToDoList.Items.Add(string.Format("Item {0}: {1}, {2}", i, data[i].A, data[i].B));
   
    // reading selected data
    // we can't convert represented by a string data back, but we can take it by index from created earlier array
    cAuditTasksEntity transaction = data[cmbToDoList.SelectedIndex];
