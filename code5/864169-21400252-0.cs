    protected void InsertButton_Click(object sender, EventArgs e)
    {
       try
       {    
            var X = new Program(); // this line is a really good place for a
                                   // breakpoint (press F9)
            X.StudentName1 = NameTxt.Text;
            X.SudentAge1 = int.Parse(AgeTxt.Text);
            X.StudentID1 = int.Parse(IDTxt.Text);
            X.Insert();
        }
        catch(Exception ex)
        {
            SomeMeaningfulAndWorkingExceptionDisplayMethod(ex);
        }
    }
    public void Insert()
    {
        const string Sql = @"
        insert into Details (StudentID,StudentName,SudentAge)
        Values (@StudentID1,@StudentName1,@SudentAge1)";
        using(var conn = new SqlConnection(DBC.Constructor))
        using(var cmd = new SqlCommand(Sql, conn))
        {
            cmd.Parameters.AddWithValue("StudentID1", StudentID);
            cmd.Parameters.AddWithValue("StudentName1", StudentName);
            cmd.Parameters.AddWithValue("StudentAge1", SudentAge);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
