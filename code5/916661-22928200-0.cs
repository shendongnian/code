        protected void myGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                string id=// To find key of current row. e.g: myGridView.DataKeys[e.RowIndex].Value.ToString();
                string text=//To find the text value from the current row.
                conn.Open();
                SqlCommand UpdateCmd = new SqlCommand(" your query");
                UpdateCmd.ExecuteNonQuery();
                conn.Close();
    GridView1.EditIndex = -1; //After updating, please set EditIndex and re-bind the GridView.
                BindGridView();
        } 
