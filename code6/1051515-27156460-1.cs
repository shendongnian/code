    if (e.CommandName.Equals("Submit"))
    {
         foreach (DataGridViewRow delItem in this.GridView1.SelectedRows)
         {
             GridView1.Rows.RemoveAt(delItem.Index);
         }
    }
   
