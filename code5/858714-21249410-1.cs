       GridViewRow gr = (GridViewRow)(((LinkButton)sender).NamingContainer);     
    
       DropDownList ddl = (DropDownList)gr.FindControl("DropDownList1");
       If(ddl.SelectedValue =="Upload")  // or u can use ddl.SelectedItem.Text
       {
          //Upload();
       }
       else if(ddl.SelectedValue == "Download")
       {
         //Download();
       }
   
