    public void Update()
    {
        sc.Open();
        try {
            using (cmd = new SqlCommand(@"UPDATE TableVotersInfo SET Education=@ed, idnum=@idnum, FirstName=@firstname, MiddleName=@middlename, LastName=@lastname, SchoolYear=@schoolyear, ControlNum=@controlnum WHERE id=@id
                                    SELECT @ed, @idnum, @firstname, @middlename, @lastname, @schoolyear, @controlnum
                                    WHERE @id NOT IN (SELECT idNum FROM TableVotersInfo);", sc))
            {
                cmd.Parameters.AddWithValue("@id", _id);
                cmd.Parameters.AddWithValue("@ed", _ed);
                cmd.Parameters.AddWithValue("@idnum", _idnum);
                cmd.Parameters.AddWithValue("@firstname", _firstname);
                cmd.Parameters.AddWithValue("@middlename", _middlename);
                cmd.Parameters.AddWithValue("@lastname", _lastname);
                cmd.Parameters.AddWithValue("@schoolyear", _schoolyear);
                cmd.Parameters.AddWithValue("@controlnum", _controlnum);
                cmd.ExecuteNonQuery();// <-- this is what you want
                MessageBox.Show("Data Successfully Updated!");
                FAddVoters._cleardata = cleardata;
                FAddVoters._checkID = "0";
            }
        } catch (SqlException ex) {
            if(ex.Number == 2627)//duplicated primary key 
            {
               MessageBox.Show("ID number already exist!");
               FAddVoters._cleardata = "0";
               FAddVoters._checkID = checkID;
            } else {
               MessageBox.Show("There was some error while attempting to update!\nTry again later.");
            }
        }
        finally {
            sc.Close();
        }
    }
