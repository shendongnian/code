    foreach (DataGridViewRow dgr in DataGridView1.Rows)
     {
        dgr.Cells["dgColTillDateCalculate"].Value = 
              (DateTime)dgr.Cells["TillDate"].Value == null 
              ? goto Outer;
              : dgr.Cells["TillDate"].Value;   
     Outer: continue;
     }
