    foreach (ListItem li in lbMess.Items)
    {
       if (li.Selected)
       {
         strSQL += string.Format("INSERT INTO message(messageContent,messageDate,staffCode) VALUES ('{0}',getdate(),'{1}');", txtMess.Text, li.Text);
       }
    
     }
