    int iColor = Color.Blue.ToArgb();
    //Store this integer value to database
    //Then retrieve that int value from database and convert it to color type 
    //by using FromArgb() method.
    Color myColor = Color.FromArgb(iColor);
    ///To store value in database
    Try
    {
        SqlCommand Cmd = Connection.CreateCommand();
        Cmd.CommandText = "Update TableName Set backColor=@backColor Where Code=@Code";
        Cmd.Parameters.Add("@backColor", SqlDBType.Int).Value = this.BackColor.ToArgb();
        Cmd.Parameters.Add("@Code", SqlDBType.Int).Value = UserCode;
        Cmd.ExecuteNonQuery();
    }
    catch(Exception ex)
    {
        Messagebox.Show(ex.Message);
    }
