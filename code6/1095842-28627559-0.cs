    public int CreateAlbum(string _titel, string _name, string _thumb, int _userid)
    {
        // define return value - newly inserted ID
    	int returnValue = -1;
    	
        // define query to be executed
        string query = @"INSERT INTO tblFotoalbum (fldAlbumHead, fldAlbumName, fldAlbumThumb, fldUserID_FK)
                                  VALUES (@titel, @name, @thumb, @userid);
                         SELECT SCOPE_IDENTITY();"
    	
        // set up SqlCommand in a using block	
        using (objCMD = new SqlCommand(query, connection)) 
    	{
    	    // add parameters using regular ".Add()" method 
            objCMD.Parameters.Add("@titel", SqlDbType.VarChar, 50).Value = _titel;
            objCMD.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = _name;
            objCMD.Parameters.Add("@thumb", SqlDbType.VarChar, 100).Value = _thumb;
            objCMD.Parameters.Add("@userid", SqlDbType.VarChar, 25).Value = _userid;
    
    		// open connection, execute query, close connection
    		connection.Open();
    		object returnObj = objCMD.ExecuteScalar();
    		
    		if(returnObj != null)
    		{
    		   int.TryParse(returnObj.ToString(), out returnValue);
    		}
    		
    		connection.Close();
        }
        
    	// return newly inserted ID
    	return returnValue;
    }
