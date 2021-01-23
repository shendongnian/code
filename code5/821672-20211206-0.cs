    List<TextBox> texboxesWithEmail = new List<TextBox>();
     
    void OnFormLoad(Object sender, EventArgs e)
    {
         texboxesWithEmail.Add(txtBx1);
         texboxesWithEmail.Add(txtBx2);
         texboxesWithEmail.Add(txtBx3);
         texboxesWithEmail.Add(txtBx4);
         texboxesWithEmail.Add(txtBx5);
    }
    void PutTextInTexboxes(string[] emails)
    {
         if(emails.Any())
         {
             for(int i = 0; i < emails.Count(); i++)
               {
                  texboxesWithEmail[i].Text = emails[i];
               }
         }
    }
    
