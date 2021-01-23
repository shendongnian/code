    protected void Page_Load(object sender, EventArgs e)
    {
                if (Request.QueryString["filename"] != null)
                {
                    //Get the content from database
                    byte[] fileContent = ....;
                    Response.Clear();
                    string doctype = ...;
                    if (doctype == ".doc")
                    {
                        Response.ContentType = "application/msword";
                    }
                    else if (doctype == ".pdf")
                    {
                        Response.ContentType = "application/pdf";
                    }
                    else if (doctype == ".xls")
                    {
                        Response.ContentType = "application/vnd.ms-excel";
                    }
                    else if (doctype == ".xlsx")
                    {
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    }
                    Response.BinaryWrite(fileContent);
                }
    }
