    private void delete_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dg = this.aSSIGNMENTDataGrid;
            var id1 = (DataRowView)dg.SelectedItem;  //Get specific ID From                DataGrid after click on Delete Button.
            PK_ID = Convert.ToInt32(id1.Row["AssignmentID"].ToString());
            SqlConnection conn = new SqlConnection(sqlstring);
            conn.Open();
            string sqlquery = "delete from ASSIGNMENT where AssignmentID='" + PK_ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            cmd.ExecuteNonQuery();
            filldatagrid();
        }
        private void filldatagrid()
        {
            SqlConnection conn = new SqlConnection(sqlstring);
            conn.Open();
            string sqlquery = "select * from ASSIGNMENT";
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            aSSIGNMENTDataGrid.ItemsSource = dt.DefaultView;
            conn.Close();
        }
