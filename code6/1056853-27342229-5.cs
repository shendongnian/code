    // Making connection to Access database via input.txt
    string fileLoc = @"C:\\input.txt";
    // reading input.txt
    String pro;
    using (StreamReader sr = new StreamReader(fileLoc))
    {
        String line = sr.ReadLine();
        pro = line;
    
        OleDbConnection con = null;
        
        con = new OleDbConnection(pro);
        con.Open();
         
        string line;
        while((line = csr.ReadLine()) != null)
        {
            // Execute SQL Commands 
            OleDbCommand comm = con.CreateCommand();
            comm.Connection = con;
            comm.CommandText = line; //<<= this to get the actual line in the file
            //Read and process data rows
            IDataReader reader = comm.ExecuteReader();
            object[] dataRow = new object[reader.FieldCount];
            string[] write = {"Maria", " Hafeez"};
            //string m = "      | {0} ";
            while (reader.Read())
            {
                int cols = reader.GetValues(dataRow);
                for (int i = 0; i < cols; i++)
                {
                    Console.Write("      | {0} ", dataRow[i]);
                }
                Console.Write("\n");
                //write = dataRow[i];
            }
            Console.WriteLine();
            Console.ReadKey();
            string path =@"C:\\output.txt";
            if (!File.Exists(path))
            {
                //output in output.txt
                File.WriteAllLines(path, write);
            }
            //Release resources and close connection   
            reader.Close();
        }
    }
