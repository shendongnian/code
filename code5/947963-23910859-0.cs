    protected void DeleteRowButton_Click(Object sender, GridViewDeleteEventArgs e)
    {
        int Part_Numbber= Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);       
        SqlCommand cmd = new SqlCommand("DELETE FROM XML WHERE Part_Numbber=" + Part_Numbber+ "", con);
        con.Open();
        int temp = cmd.ExecuteNonQuery();
        if (temp == 1)
        {
            lblMessage.Text = "Record deleted successfully";
        }
        con.Close();
        FillGrid();
    }
