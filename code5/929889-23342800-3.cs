    private string ConnectionString  = webConfigurationManager.ConnectionStrings["connectionstring"] != null ? WebConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString : "";
    
    if (!string.IsNullOrEmpty(this.ConnectionString))
    {
    using (var sqlConnection = new SqlConnection(this.ConnectionString))
    {
        //your code here
    }
    }
