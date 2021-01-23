    try
    {
        using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDatabase"].ConnectionString))
        {
            //open connection with database
            connection.Open();
    
            //query to select all users with teh given username
            var command1 = new SqlCommand("insert into artikulli (tema,abstrakti, kategoria_id, keywords ) values (@tema, @abstrakti, @kategoria, @keywords)", connection);
    
            command1.Parameters.AddWithValue("@tema", InputTitle.Value);
            command1.Parameters.AddWithValue("@abstrakti", TextareaAbstract.Value);
            command1.Parameters.AddWithValue("@kategoria", DropdownCategory.Value);
            command1.Parameters.AddWithValue("@keywords", InputTags.Value);
    
            //execute first query
            command1.ExecuteNonQuery();
    
            //build second query
            string filename = "artikuj/" + Path.GetFileName(FileUploadArtikull.PostedFile.FileName);
            SqlCommand command2 = new SqlCommand("insert into artikulli(path) values ('@filename')", connection);
    
            //add parameters
            command2.Parameters.AddWithValue("@filename", filename);
    
            //execute second query
            command2.ExecuteNonQuery();
    
        }
    }
    //TODO: add some exception handling
    //simply wrapping code in a try block has no effect without a catch/finally
