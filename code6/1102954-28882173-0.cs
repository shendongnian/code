    int refcodenum = getOrderNum();
    string refcode = "E" + refcodenum;
    byte[] personalpic = getBarcode(refcodenum);
    var sqlCmdText = "Update Clients set ReferenceNumber='" + refcode + "',ReferenceBarcode=@photo where NetNumber='"+id+"'";
    
    try
    {
        using (var sqlConnection = new SqlConnection([YOUR CONNECTION STRING HERE]))
        {
            using (var sqlCommand = new SqlCommand(sqlCmdText, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;
    
                sqlCommand.Parameters.Add("@photo", SqlDbType.Image, personalpic.Length).Value = personalpic;
                sqlConnection.Open();
    
                sqlCommand.ExecuteNonQuery();
    
            }
        }
    }
    catch (Exception ex)
    {
        throw new DataException(ex.Message);
    }
