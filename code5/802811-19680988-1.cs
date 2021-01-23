    using(var con = new SqlConnection("connection-string"))
    using(var cmd = new SqlCommand("UPDATE dbo.TableName SET DateColumn=@DateColumn WHERE PK=@PK", con))
    {
        DateTime reg_tes = DateTime.ParseExact(Reg_tes.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        cmd.Parameters.AddWithvalue("@DateColumn", reg_tes);
        // other parameters ...
        con.Open();
        int affected = cmd.executeNonQuery();
    }
