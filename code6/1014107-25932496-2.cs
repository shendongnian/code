    protected void Page_Init(object sender, EventArgs e)
        {
            GridView1.DataBind(); //Key code
        }
        protected void gv_DataBound(object sender, EventArgs e)
        {
            
                    Button delete = new Button();
                   delete.ID = "btnDelete_" + i;
                    delete.ToolTip = "Delete";
                   delete.CssClass = "tagBubbleDelete";
                   delete.CommandName = "Delete";
                   delete.CommandArgument = imageID.Text;
                
            
        }
        protected void gv_RowCommand(object sender, CommandEventArgs e) //Your grid view function change accroding you need!!
        {
            if (e.CommandName == "Delete")
            {
            }
        }
