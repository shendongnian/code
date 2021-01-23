	Try this code:
	protected void btnDelete_Click(object sender, EventArgs e)
	{
	foreach (GridViewRow gvrow in gvDetails.Rows)
	{
	//Finiding checkbox control in gridview for particular row
	CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkSelect");
	//Condition to check checkbox selected or not
	if (chkdelete.Checked)
	{
	//Getting UserId of particular row using datakey value
	int usrid = Convert.ToInt32(gvDetails.DataKeys[gvrow.RowIndex].Value);
	using (SqlConnection con = new SqlConnection("Data Source=Test;Integrated Security=true;Initial Catalog=MySampleDB"))
	{
	con.Open();
	SqlCommand cmd = new SqlCommand("delete from UserDetails where UserId=" + usrid, con);
	cmd.ExecuteNonQuery();
	con.Close();
	}
	}
	}
