       private static string FunctionToDynamicallyCreateConnectionstring()
       {
            string path = Properties.Settings.Default.swPath;
            if (path != null)
            {
                StreamReader sr = new StreamReader(File.Open(path, FileMode.Open));
                SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
                cb.DataSource = DecodeFrom64(sr.ReadLine());
                cb.InitialCatalog = DecodeFrom64(sr.ReadLine());
                cb.UserID = DecodeFrom64(sr.ReadLine());
                cb.Password = DecodeFrom64(sr.ReadLine());
                return cb.ToString(); 
           }
           else
                return string.Empty
       }
