    private void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateDB();
        dataGridView2.Update();
        dataGridView2.Refresh();
    }
    
    private void UpdateDB()
    {
        using (DbConnection con = Helper.getconnection())
        {
            con.Open();
           
            using(DbCommand cmd = con.CreateCommand("Update Projects set ProjectName= @PrjName, Description=@Description, DateStarted=@Date, TeamSize=@Size,Manager=@Manager where ProjectID=@PrjID "))
            {
    
               cmd.CommandType = CommandType.Text;
               cmd.Parameters.Add(new SqlParameter("PrjName", txtPrjNmae.Text));
               cmd.Parameters.Add(new SqlParameter("Description", txtPrjdescription.Text));
               cmd.Parameters.Add(new SqlParameter("Date", txtPrjDate.Text));
               cmd.Parameters.Add(new SqlParameter("Size", txtPrjSize.Text));
               cmd.Parameters.Add(new SqlParameter("Manager", txtPrjManager.Text));
               cmd.Parameters.Add(new SqlParameter("PrjID", txtPrjID.Text));
               cmd.Connection = con;
    
               cmd.ExecuteNonQuery();
            }
        }
    }
