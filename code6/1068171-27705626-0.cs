     protected void RadButton1_Click(object sender, EventArgs e)
            {
    
               
                ContentPlaceHolder contentPage = Page.Master.FindControl("ContentPlaceHolder2") as ContentPlaceHolder;
                RadButton radbutton1 = (RadButton)contentPage.FindControl("RadButton1");
                object mysender = (object)radbutton1;
                CommandEventArgs e2 = new CommandEventArgs(null, radbutton1.CommandArgument);
                RadButton1_Click(mysender, e2);
                TreeListCommandEventArgs e1 = new TreeListCommandEventArgs(null,radbutton1.CommandArgument,e2);
                TreeListDataItem dataItem = e1.Item as TreeListDataItem;
                Hashtable table = new Hashtable();
                table["PartyParentRowId"] = (dataItem.FindControl("Label1") as Label).Text;
                table["PartyAlias"] = (dataItem.FindControl("Label2") as Label).Text;
            
            }
