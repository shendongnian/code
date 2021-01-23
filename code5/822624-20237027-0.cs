    OleDbConnection myConnection = null;
    try
    {
       //save image to byte array and allocate enough memory for the image
       byte[] imagedata = image.ToByteArray(new Atalasoft.Imaging.Codec.JpegEncoder(75));
    
       //create the SQL statement to add the image data
       myConnection = new OleDbConnection(CONNECTION_STRING);
       OleDbCommand myCommand = new OleDbCommand("INSERT INTO Atalasoft_Image_Database (Caption, ImageData) VALUES ('" + txtCaption.Text + "', ?)", myConnection);
       OleDbParameter myParameter = new OleDbParameter("@Image", OleDbType.LongVarBinary, imagedata.Length);
       myParameter.Value = imagedata;
       myCommand.Parameters.Add(myParameter);
    
       //open the connection and execture the statement
       myConnection.Open();
       myCommand.ExecuteNonQuery();
    }
    finally
    {
       myConnection.Close();
    }
