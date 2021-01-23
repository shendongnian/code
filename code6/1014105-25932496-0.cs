    protected void Page_Init(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            
                    Button delete = new Button();
                   delete.ID = "btnDelete_" + i;
                    delete.ToolTip = "Delete";
                   delete.CssClass = "tagBubbleDelete";
                   delete.CommandName = "Delete";
                   delete.CommandArgument = imageID.Text;
                
            
        }
        protected void Button_Command(object sender, CommandEventArgs e) //Your grid view function change accroding you need!!
        {
            if (e.CommandName == "Delete")
            {
            }
        }
