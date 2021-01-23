    private void button1_Click(object sender, EventArgs e)
    {
        // INITIALIZE 
        using(SqlConnection conn = new SqlConnection("......"))
        {
             // OPEN
             conn.Open();
             string query = "INSERT INTO empleados VALUES (@Nombre, @Apellidos, @Departamento, @Carnet)";
             // USE
             using(SqlCommand vCom = new SqlCommand(query, conn))
             {
                 ....
             }
        } // <- CLOSE & DISPOSE
    }
