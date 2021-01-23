    protected void submitButton_Click(object sender, EventArgs e)
    {
        //string constr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=~\App_Data\TravelJoansDB.accdb";
        string constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database21.accdb;Persist Security Info=False;";
        string cmdstr = "INSERT INTO Comments(commentText,datePosted,personName) VALUES (@txtComments, @datePosted, @personName)";
        OleDbConnection con = new OleDbConnection(constr);
        OleDbCommand com = new OleDbCommand(cmdstr, con);
        TextBox tComments = (TextBox)FormView1.FindControl("txtComments");
        HiddenField tDate = (HiddenField)FormView1.FindControl("hidTimeDate");
        TextBox tName = (TextBox)FormView1.FindControl("txtName");
        con.Open();
        com.Parameters.AddWithValue("@txtComments", tComments.Text);
        com.Parameters.AddWithValue("@datePosted", DateTime.Now.ToString());
        //com.Parameters.AddWithValue("@datePosted", tDate.Value.ToString());
        com.Parameters.AddWithValue("@personName", tName.Text);
        com.ExecuteNonQuery();
        con.Close();
    }
    protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
    { 
    }
