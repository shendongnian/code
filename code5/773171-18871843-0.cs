    bool _closedByTransferButton = false;
    public List<DataGridViewRow> ShowForm() 
    { 
       ShowDialog();
       List<DataGridViewRow> res = new List<DataGridViewRow>();
       if(_closedByTransferButton)
       {
           for(int i = 0;i<grid.Rows.Count;i++)
               if((bool)grid.Rows[i].Cells["checkboxColumn"].Value)
                   res.Add(grid.Rows[i]);
       }
       return res;
    }
