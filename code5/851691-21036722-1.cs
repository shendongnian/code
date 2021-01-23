    ProjList = new List<ProjectMasterRec>();  
    
    foreach (DataGridViewRow dr in dataGridView1.Rows)
    {
        ProjectMasterRec pl = new ProjectMasterRec();
        pl.Property1 = dr.Cells[1].Value;
        pl.Property2 = dr.Cells[2].Value;
        pl.Property3 = dr.Cells[3].Value;
        
        //Add pl to your List  
        ProjList.Add(pl);     
    }
    
