    string WKTRepresentation = "LINESTRING (100 100, 20 180, 180 180)";
    using (SqlConnection conn = new SqlConnection("connectionString"))
    using (SqlCommand cmd = new SqlCommand("SELECT geometry::STGeomFromText(@WKT, 0)", conn))
    {
        conn.Open();
        cmd.Parameters.Add(new SqlParameter("@WKT", SqlDbType.NVarChar) { Value = WKTRepresentation });
        var reader = cmd.ExecuteReader();
    }
