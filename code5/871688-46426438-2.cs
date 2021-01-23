    protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gv.Rows[e.RowIndex];
    
        string serial = row.Cells[1].Controls[0];
        string name = row.Cells[2].Controls[0]);
        string cost = row.Cells[3].Controls[0]);
        string number = row.Cells[4].Controls[0]);
        yourtextbox_Id.text = serial;
        nametextbox.text = name;
        costtextbox.text = cost ;
        numbertextbox.text = number ;
    // do like this
    
        string query = String.Format("UPDATE games SET name='{1}', cost={2}, number={4} WHERE serial={0}",
                                    serial.Text, name.Text, cost.Text, number.Text);
    
        SqlConnection connect = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, connect);
        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
    
        this.gv.EditIndex = -1;
        BindTheGridView();
    }
