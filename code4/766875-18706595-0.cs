        private void CheckConnection()
        {
             string connetionString = null;
            SqlConnection cnn ;
			connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password" 
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
        }
