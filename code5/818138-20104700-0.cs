    protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)Grd.HeaderRow.FindControl("chkboxSelectAll");
        
        foreach (GridViewRow row in Grd.Rows)
        {
            // Only look in data rows, ignore header and footer rows
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkEmp");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                    var id = Grd.DataKeys[row.RowIndex].Value;
                    SqlConnection con = new SqlConnection(constr);
                    string qry = "delete from empdetail where id=@id";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    bindgrid();
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }
    }
