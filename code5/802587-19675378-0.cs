    public void Add()
    {
        sc.Open();
        try
        {
            using(cmd = new SqlCommand(@"INSERT INTO TableVotersInfo (Education, idnum, FirstName, MiddleName, LastName, SchoolYear, ControlNum, VResult)
                                            SELECT @ed, @idnum, @firstname, @middlename, @lastname, @schoolyear, @controlnum, 'Not Voted' 
                                            WHERE @idNum NOT IN (SELECT idNum FROM TableVotersInfo);", sc))
            {
                cmd.Parameters.AddWithValue("@id", _id);
                cmd.Parameters.AddWithValue("@ed", _ed);
                cmd.Parameters.AddWithValue("@idnum", _idnum);
                cmd.Parameters.AddWithValue("@firstname", _firstname);
                cmd.Parameters.AddWithValue("@middlename", _middlename);
                cmd.Parameters.AddWithValue("@lastname", _lastname);
                cmd.Parameters.AddWithValue("@schoolyear", _schoolyear);
                cmd.Parameters.AddWithValue("@controlnum", _controlnum);
                var rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected == 0)
                {
                    MessageBox.Show("ID number already exist!");
                }
                else
                {
                    MessageBox.Show("Data Stored Successfully!");
                    FAddVoters._cleardata = cleardata;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            sc.Close();
        }
    }
