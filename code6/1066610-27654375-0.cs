     protected void btn_file_upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                byte[] byte_file = FileUpload1.FileBytes;
                string str_file = Convert.ToBase64String(byte_file);
                SqlCommand cmd = new SqlCommand("insert into spt_files values('" + FileUpload1.FileName.Replace("'", "''") + "','" + str_file + "','" + dd_students.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                lbl_file_upload.Text = "File uploaded!";
            }
            else
                lbl_file_upload.Text = "Choose a file";
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
