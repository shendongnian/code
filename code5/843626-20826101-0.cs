      protected void gvIqamaAlert_RowUpdating(object sender, GridViewUpdateEventArgs e)
  {
   
       Label l = (Label)gvIqamaAlert.Rows[e.RowIndex].FindControl("Label1");
    string jobId = gvIqamaAlert.DataKeys[e.RowIndex].Value.ToString();
    TextBox fname = (TextBox)gvIqamaAlert.FindControl("txtfname");
    TextBox IssP = (TextBox)gvIqamaAlert.FindControl("txtIssP");
    if(l == null || fname == null || IssP == null) return;
    ////TextBox Issd = (TextBox)gvIqamaAlert.FindControl("txtIssd");
    ////temp1 = ((TextBox)gvIqamaAlert.FindControl("txtIssd")).Text;
    //DateTime Iss = DateTime.ParseExact(Greg(((TextBox)gvIqamaAlert.FindControl("txtIssd")).Text), "dd/MM/yyyy", null);
    //TextBox Expd = (TextBox)gvIqamaAlert.FindControl("txtExpd");
    //temp2 = Greg(Expd.ToString());
    //DateTime Exp = DateTime.ParseExact(temp2, "dd/MM/yyyy", null);
    con.Open();
    SqlCommand cmd = new SqlCommand("Update Employee set FName='" + fname.Text + "',IDIssPlace='" + IssP.Text + "' where EmpNo='" + Convert.ToString(l.Text) + "'", con);
    cmd.Parameters.AddWithValue("@id", jobId);
    //,IDIssDate = @iss, IDExpDate = @exp
    //cmd.Parameters.AddWithValue("@iss",Iss);
    //cmd.Parameters.AddWithValue("@exp", Exp);
    cmd.ExecuteNonQuery();
    con.Close();
    gvIqamaAlert.EditIndex = -1;
    BindEmployeeDetails();
