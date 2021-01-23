 static public void InsertMember(String _MemberId, String _Surname, String _Forename, String _Phonenumber, String _Email, String _Country, String _CityTown, String _CountyZipCode)
    {
        try
        {
            connection.Open();
            SqlCeCommand commandInsert = new SqlCeCommand("INSERT INTO [Members] VALUES(@MemberID, @Surname, @Forename, @Phonenumber, @Email, @Country, @CityTown, @CountyZipCode)", connection);
            commandInsert.Parameters.AddWithValue("@MemberID", _MemberId);     
            commandInsert.Parameters.AddWithValue("@Surname", _Surname);
            commandInsert.Parameters.AddWithValue("@Forename", _Forename);
            commandInsert.Parameters.AddWithValue("@Phonenumber", _Phonenumber);
            commandInsert.Parameters.AddWithValue("@Email", _Email);
            commandInsert.Parameters.AddWithValue("@Country", _Country);
            commandInsert.Parameters.AddWithValue("@CityTown", _CityTown);
            commandInsert.Parameters.AddWithValue("@CountyZipCode", _CountyZipCode);
            commandInsert.ExecuteNonQuery();
        }
        catch (SqlCeException exeptions)
        {
            MessageBox.Show(exeptions.ToString());
        }
        finally
        {
            connection.Close();
        }
