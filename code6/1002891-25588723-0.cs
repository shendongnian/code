    SqlDataAdapter sda = new SqlDataAdapter();
    DataTable dt;
    SqlCommand cmd2 = new SqlCommand();
    
    protected void Page_Load(object sender, EventArgs e)
        {
            string sql = @"SELECT Invoice.[InvoiceID], Invoice.[CustomerID], Invoice.[Date], Invoice.[Amount], Invoice.[Paid], Invoice.[Rest], Invoice.[PaymentType], Invoice.[Shipped], Customer.[CustomerID], Customer.[Name], Customer.[Tell], Customer.[Address], Customer.[Comment] FROM [Invoice] INNER JOIN [Customer] ON Invoice.[CustomerID] = Customer.[CustomerID]";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RechnungConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                conn.Close();
            }
        } 
    
    protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
               dt = new DataTable();
                 
                cmd2 =
                    new SqlCeCommand(string.Format(@"SELECT Invoice.[InvoiceID], Invoice.[CustomerID], Invoice.[Date], Invoice.[Amount], Invoice.[Paid], Invoice.[Rest], Invoice.[PaymentType], Invoice.[Shipped], Customer.[CustomerID], Customer.[Name], Customer.[Tell], Customer.[Address], Customer.[Comment] FROM [Invoice] INNER JOIN [Customer] ON Invoice.[CustomerID] = Customer.[CustomerID] where Name LIKE '%{0}%'", TextBox1.Text));
                try
                {
                    adp1.SelectCommand = cmd2;
                    adp1.Fill(dt);
    GridView1.DataSource = dt;
                }
                finally
                {
                    con.Close();
                }
    
        }
