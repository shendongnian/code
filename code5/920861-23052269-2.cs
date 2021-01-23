    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    bindGridWithFilter();
                }
            }
    
            protected void gvwAssociation_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                gvwAssociation.PageIndex = e.NewPageIndex;
                bindGridWithFilter();
            }
    
            protected void btnSearch_Click(object sender, EventArgs e)
            {
                bindGridWithFilter();
    
            }
    
            private void bindGridWithFilter()
            {
                List<EventFile> eventFile = new List<EventFile>();
                eventFile = CoMailAssociationDAL.GetUploadFileUnAssigned(0, "", "", "U");
                if (gvwAssociation.DataSource == null) 
                {
                    // If you don't have a filter you show all records
                    gvwAssociation.DataSource = eventFile;
                    gvwAssociation.DataBind();
                }
                else
                {
                    // This is same as the logic in your search button
                    // display only the filtered records
                    int uFlag = 0;
                    string uploadFlag = this.ddlUploadDate.SelectedValue;
                    string fileName = this.txtSearchText.Text;
                    string uploadDt = this.txtDate.Text;
                    string status = this.ddlStatus.SelectedValue.ToString();
                    bt = true;
    
    
                    if (status == "Un-Assigned")
                    {
                        status = "U";
                    }
                    else if (status == "Assigned")
                    {
                        status = "A";
                    }
                    else
                    {
                        status = "B";
                    }
    
    
                    if ((uploadFlag == "On") && (uploadDt == ""))
                    {
                        uFlag = 0;
                    }
                    else if (uploadFlag == "On")
                    {
                        uFlag = 1;
                    }
                    else if (uploadFlag == "OnorBefore")
                    {
                        uFlag = 2;
                    }
                    else
                    {
                        uFlag = 3;
                    }
    
    
                    List<EventFile> fileSearch = CoMailAssociationDAL.SearchFile(uFlag, fileName, uploadDt, status);
    
                    gvwAssociation.DataSource = fileSearch;
                    gvwAssociation.DataBind();
                }
            }
