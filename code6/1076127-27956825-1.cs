    // **** Read Image from Filesystem and add it to the Database.
            public void AddFileDataIntoDatabase(
                string a,string b,string c, string photoFilePath)
            {
    
                // Read Image into Byte Array from Filesystem
                byte[] photo = GetPhoto(photoFilePath);
    
                // Construct INSERT Command
                SqlCommand addEmp = new SqlCommand(
                    "INSERT INTO tablename ("+
                    "col1,col2,Col3,Photo) "+
                    "VALUES(@col1,@col2,@col3,@Photo)",_conn);
    
                addEmp.Parameters.Add("@col1",  SqlDbType.NVarChar, 20).Value = plastName;
                addEmp.Parameters.Add("@col2", SqlDbType.NVarChar, 10).Value = pfirstName;
                addEmp.Parameters.Add("@col3",     SqlDbType.NVarChar, 30).Value = ptitle;                
                addEmp.Parameters.Add("@Photo",     SqlDbType.Image, photo.Length).Value = photo;
    
                // Open the Connection and INSERT the BLOB into the Database
                _conn.Open();
                addEmp.ExecuteNonQuery();
                _conn.Close();
            }
