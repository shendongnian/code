        try
        {
            //firing command
            string strCommand = "UPDATE [Data] SET catagory = @catagory WHERE (id =@id)";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.Parameters.AddWithValue("@catagory",catagory);
            objCommand.Parameters.AddWithValue("@id",id);
            int status;
            status = objCommand.ExecuteNonQuery();
            if(status>0)
               MessageBox.Show("Data Updated Successfully!");
            else
               MessageBox.Show("Update Failed!");
        }
