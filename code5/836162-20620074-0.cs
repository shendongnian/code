    public static void AddBand(Band band){
        try
        {
            String sql = "INSERT INTO Band(Naam, Picture, Description, Facebook, Twitter) VALUES(@p1,@p2,@p3,@p4,@p5)";
            DbParameter p1 = Database.AddParameter("@p1", band.Name);
            DbParameter p2 = Database.AddParameter("@p2", band.Picture 
                ?? DBNull.Value);
            DbParameter p3 = Database.AddParameter("@p3", band.Description 
                ?? DBNull.Value);
            DbParameter p4 = Database.AddParameter("@p4", band.Facebook);
            DbParameter p5 = Database.AddParameter("@p5", band.Twitter);
            Database.ModifyData(sql, p1, p2, p3, p4, p5);
            MessageBox.Show("Band successfully added.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
