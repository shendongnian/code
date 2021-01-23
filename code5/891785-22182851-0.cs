    protected void AddDuesbtn_Click(object sender, EventArgs e)
    {
       for (int i = 0; i < StdDueNmcklist.Items.Count; i++)
       {
           if (StdDueNmcklist.Items[i].Selected)
           {
               InsertStudDuesdatcon.Insert();
               AddDuesbtn.Visible = false;
               CnfrmStudDueAddlbl.Visible = true;
               CnfrmStudDueAddbtn.Visible = true;
               StdDueNmcklist.Items[i].Selected = false;
           }
            
       
         }
