    public class MyClass
    {
        public string id_art { get; set; }
        public string nombre { get; set; }
        public string precio { get; set; }
    }
    SqlConnection cnx;
    String cadCnx = "Here goes my credentials"
    cnx = new SqlConnection(cadCnx);
    String query = "exec SP_Datos_PDF @fact";
    SqlCommand cmd = new SqlCommand(query, cnx);
    cmd.Parameters.AddWithValue("@fact", SqlDbType.Int).Value = fact;
    cnx.Open();  
    DataTable dt = new DataTable();
    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    adp.Fill(dt);
    if (dt.Rows.Count > 0)
    {
        for (int i = 0; i <= filas; i++)
        {
            DataRow row = dt.Rows[0];
             var item = new MyClass();
             item.id_art = Convert.ToString("id_art");
             item.nombre = Convert.ToString("nombre");
             item.precio = Convert.ToString("precio");
             Items.Add(item);  
             i++;
        }
    }
