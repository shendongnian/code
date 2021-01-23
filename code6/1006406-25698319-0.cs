    protected void btnEnter_Click(object sender, EventArgs e)
       {
          string hobbies = "";
          for (int i=0;i<chkListHobbies.Items.Count;i++)
          {
             if (chkListHobbies.Items[i].Selected)
             {                
                hobbies += chkListHobbies.Items[i].Value + ",";
              }
    
        }
       hobbies = hobbies.TrimEnd(',');
       Response.Write("Hobbies=" + hobbies);
