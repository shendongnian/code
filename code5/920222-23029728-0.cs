    Public Static SqlConnection GetConnection()
    {
    SqlConnection cnn = new SqlConnection();
    cnn.ConnectionString = configurationManager.ConnectionStrings["Courier_Management_System"].ToString();
    return cnn;
    }
