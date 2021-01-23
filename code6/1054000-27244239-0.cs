    protected void imgs_Click(object sender, ImageClickEventArgs e)  
            {  
      
            foreach (RepeaterItem ri in repeater.Items)
            {
            CheckBox item_check = (CheckBox)ri.FindControl("item_check");
            Label txt_id = (Label)ri.FindControl("txt_id");
                if (item_check.Checked)
                {
                    con = new SqlConnection(strcon);
                    SqlCommand cmd = new SqlCommand("ram", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add("@Action",SqlDbType.Varchar,50).Value="DELETE";
                    cmd.Parameters.Add("@eid",SqlDbType.Int).Value=Convert.ToInt16(txt_id.Text);
                    cmd.ExecuteNonQuery();
                   repeat();
               }                
        }     
}
