     private void btnAdd_Click(object sender, EventArgs e)
    {
        tblSessionTableAdapter tblSession = new tblSessionTableAdapter();
        tblSession.Update(this.ds);  // update persistent data set
    }
