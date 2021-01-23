    protected void BindFilteredData()
     {
                string sqlConnectString = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ToString();
                string sqlSelect = "SELECT  cmsContentXml.nodeId,text, Max(updateDate) as UpdateDate,expireDate as ExpireDate from cmsContentXml,cmsDocument,cmsContent where cmsContent.nodeId=cmsContentXml.nodeId and cmsDocument.nodeId=cmsContent.nodeId  and text like '%" + TextBox1.Text + "%' group by cmsContentXml.nodeId,text,expireDate";
    
                SqlConnection sqlConnection = new SqlConnection(sqlConnectString);
                SqlCommand sqlCommand = new SqlCommand(sqlSelect, sqlConnection);
    
    
    
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand);
                DataTable sqlDt = new DataTable();
                sqlDa.Fill(sqlDt);
                GridViewFoundations.DataSource = sqlDt;
                GridViewFoundations.DataBind();
    }
