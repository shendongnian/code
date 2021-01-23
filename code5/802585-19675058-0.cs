    public void Add()
    {
        sc.Open();
        try
        {
            cmd = new SqlCommand("Select idnum from TableVotersInfo Where idnum=@idnum", sc);
            cmd.Parameters.AddWithValue("@idnum", _idnum);
            if (cmd.ExecuteScalar() != null)
            {
                MessageBox.Show("ID number already exist!");
                rd.Close();
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO TableVotersInfo (Education, idnum, FirstName, MiddleName, LastName, SchoolYear, ControlNum, VResult) VALUES (@ed, @idnum, @firstname, @middlename, @lastname, @schoolyear, @controlnum, 'Not Voted');", sc);
                cmd.Parameters.AddWithValue("@id", _id);
                cmd.Parameters.AddWithValue("@ed", _ed);
                cmd.Parameters.AddWithValue("@idnum", _idnum);
                cmd.Parameters.AddWithValue("@firstname", _firstname);
                cmd.Parameters.AddWithValue("@middlename", _middlename);
                cmd.Parameters.AddWithValue("@lastname", _lastname);
                cmd.Parameters.AddWithValue("@schoolyear", _schoolyear);
                cmd.Parameters.AddWithValue("@controlnum", _controlnum);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Stored Successfully!");
                FAddVoters._cleardata = cleardata;
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
