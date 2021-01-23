    protected void Chart1_Load(object sender, EventArgs e)
    {
        
        SqlCommand cmd = new SqlCommand("sp_chart", Cn); // Definir cmd
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@id_district", SqlDbType.Int);
        cmd.Parameters["@id_district"].Value = 1;
        Cn.Open();
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        Graficas.DataSource = reader;
        Graficas.Series[0].XValueMember = "name";
        Graficas.Series[0].YValueMembers = "vote";
        Graficas.DataBind();
       
        reader.Close();
        Cn.Close();
        
    }
