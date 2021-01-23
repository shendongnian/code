    protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = GetQuery();
            cmd.Connection = conn;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            FillTable(reader);
            cmd.Connection.Close();
        }
        private SqlCommand GetQuery()
        {
            SqlCommand cmd = new SqlCommand();
            int value = -1;
            if (int.TryParse(TextBox1.Text, out value))
            {
                cmd.CommandText = "select c.id,p.Nume, c.Banca,c.Sold,c.Unitate,c.Data_Deschiderii from Cont c,Persoana p where c.Sold>=@Sold and p.Id = c.id_persoana";
                cmd.Parameters.Add(new SqlParameter("@Sold", value));
            }
            else
            {
                cmd.CommandText = "select c.id,p.Nume, c.Banca,c.Sold,c.Unitate,c.Data_Deschiderii from Cont c,Persoana p where p.Id = c.id_persoana";
            }
            return cmd;
        }
