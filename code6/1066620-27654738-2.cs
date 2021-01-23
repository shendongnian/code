    using(SqlConnection sc = new SqlConnection(conString))
    using(SqlCommand cmd = sc.CreateCommand())
    {
       cmd.CommandText = "SELECT * FROM glossary";
       ...
       using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
       {
          DataTable table = new DataTable();
          sda.Fill(table);
          if(dt.Rows.Count > 0)
             MessageBox.Show(table.Rows[0].ItemArray[3].ToString());
       }
    }
