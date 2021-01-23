    string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MovieLibrary.accdb";
    using(OleDbConnection connect = new OleDbConnection(conString))
    {
         connect.Open();
         string addnew = @"UPDATE tblLoan set MovieID=?, DateIssued=?, DateReturned=?,
                           WHERE MemberID=?";
         using(OleDbCommand com = new OleDbCommand(addnew, connect))
         {
             com.Parameters.AddWithValue("@p1", Convert.ToInt32(this.txtMovieID.Text)
             com.Parameters.AddWithValue("@p2", Convert.ToDateTime(this.txtDateIssued.Text)
             com.Parameters.AddWithValue("@p3", Convert.ToDateTime(this.txtDateReturned.Text )
             com.Parameters.AddWithValue("@p4", Convert.ToInt32(this.txtMemberID.Text )
             com.ExecuteNonQuery();
             MessageBox.Show("Successfully returned..");
         }
    }
