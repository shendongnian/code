    private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
    {
         var obj = sender as CheckEdit;
         if(obj.Tag != null)
         {
             obj.Checked = true;
             repositoryItemCheckEdit1.Enabled = false;
         }
         else
         {
             if (obj.Checked)
             {
                obj.Tag = true;
                repositoryItemCheckEdit1.Enabled = false;                
             }
         }
    }
