      protected void InsertButton_Click(object sender, EventArgs e)
    {
  
    
        Insert(name.txt,convert.to.int16(AgeTxt.Text),convert.to.int16(IDTxt.Text));
    }
    // Insert Method 
     public void Insert(string name,int age,int studentid)
    {
              SqlConnection Connection = new SqlConnection(DBC.Constructor);
            string Sql = "insert into Details (StudentID,StudentName,SudentAge) Values    (@StudentID1,@StudentName1,@SudentAge1)";
              SqlCommand Command = new SqlCommand(Sql, Connection);
             Command.Parameters.AddWithValue("@StudentID1", studentid);
              Command.Parameters.AddWithValue("@StudentName1", name);
              Command.Parameters.AddWithValue("@StudentAge1", age);
         try
         {
        Connection.Open();
        Command.ExecuteNonQuery();
        try
        {
            Console.WriteLine("Execute success");
        }
        catch
        {
            Console.WriteLine("Execute is not success");
        }
    }
    catch
    {
        Console.WriteLine("Error saving Student");
    }
    finally
    {
        try
        {
            Connection.Close();
        }
        catch
        {
        }
    }
     }
