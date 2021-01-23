        protected void Upload_Click(object sender, EventArgs e)
         {
         using (BinaryReader reader= new BinaryReader(FileUpload1.PostedFile.InputStream))
         {
          byte[] bytes = reader.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);
          // Add Here your sql query and give upload path
          }
         and on your page load Bind the DataList 
