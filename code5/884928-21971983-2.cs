        try
        {
            //firing command
            string strCommand = "UPDATE [Data] SET catagory = @category WHERE (id =@id)";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.Parameters.AddWithValue("@category",category);
            objCommand.Parameters.AddWithValue("@id",id);
            int status;
            status = objCommand.ExecuteNonQuery();
            if(status>0)
               MessageBox.Show("Data Updated Successfully!");
            else
               MessageBox.Show("Update Failed!");
        }
