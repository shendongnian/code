       protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
       {
         if(e.CommandName=="Delete") 
         {
          // Get the value of command argument
          int Id= convert.ToInt32(e.CommandArgument);
          // Do whatever operation you want.  
         }
       }
