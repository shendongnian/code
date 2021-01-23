    public void YourMethod() {
        string connStr = ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString.ToString();
        using(SqlConnection connection = new SqlConnection()) {
            //do something
        }
    }
