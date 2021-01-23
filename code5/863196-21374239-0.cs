    public DataTable GetData(int OrderQuantity)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            SqlDataAdapter sa = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT  [RmId],[RmName],[MeasuringUnit],[Rate],([Qty]/OrderQuantity )as Qty,[BagSz]FROM [dbo].[RawMaterials]",con);
            sa.SelectCommand = cmd;
            sa.Fill(dt);
            con.Close();
            return dt;
        }
