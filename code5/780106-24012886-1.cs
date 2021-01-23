    private DataTable GetImageRow(DataTable dt, string ImageName)
        {
            try
            {
                FileStream fs;
                BinaryReader br;
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + ImageName))
                {
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + ImageName, FileMode.Open);
                }
                else
                {
                    // if phot does not exist show the nophoto.jpg file 
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "nophoto.jpg", FileMode.Open);
                }
                // initialise the binary reader from file streamobject 
                br = new BinaryReader(fs);
                // define the byte array of filelength 
                byte[] imgbyte = new byte[fs.Length + 1];
                // read the bytes from the binary reader 
                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
                dt.Rows[0]["Image"] = imgbyte;
                br.Close();
                // close the binary reader 
                fs.Close();
                // close the file stream 
              
            }
            catch (Exception ex)
            {
                // error handling 
                MessageBox.Show("Missing " + ImageName + "or nophoto.jpg in application folder");
            }
            return dt;
            // Return Datatable After Image Row Insertion
 
        }
