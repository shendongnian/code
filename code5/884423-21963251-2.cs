    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int index = 0;
        int id = 0;
    
        if (int.TryParse(hdnIndex.Value, out index))
        {
            GridViewRow gvr = gridView.Rows[index];
            if (gvr != null &&  int.TryParse(gvr.Cells[0].Text, out id) )
            {
                // id is available here
                // do wahtever you want  with the id
                // even you can delete the record from db by id
            }               
        }
    }
     
