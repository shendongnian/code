        protected void MyCheckBoxInGrid_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            GridViewRow row = ((GridViewRow)chk.NamingContainer);
            
            
           
            if (chk.Checked)
            {
                
                ImageButton imgButton = row.FindControl("ImgDetail") as ImageButton;
                MyGridView_RowCommand(MyGridView, new GridViewCommandEventArgs(imgButton , new CommandEventArgs(imgButton .CommandName, imgButton .CommandArgument)));
            }}
