     private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow r = gridView1.GetDataRow(e.RowHandle);
            
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.MARKETConnectionString))
            {
                conn.Open();
                
                dataAdapter.UpdateCommand = conn.CreateCommand();
                dataAdapter.UpdateCommand.CommandText = "UPDATE TestTimeLinked set SecondName = @Name where Id = @Id";
                dataAdapter.UpdateCommand.Parameters.AddWithValue("Name", r.Field<string>("SecondName"));
                dataAdapter.UpdateCommand.Parameters.AddWithValue("Id", r.Field<int>("ID"));
                dataAdapter.UpdateCommand.ExecuteNonQuery();
            }
        }
