    static void Main(string[] args)
    {
        string CurrentAreaCode = "415";// Input from textbox;
        // Setup Mock Dataset
        DataSet ds = new DataSet("Information");
        ds.Tables.Add("AreaCodeInformation");
        ds.Tables[0].Columns.Add("AreaCode");
        ds.Tables[0].Columns.Add("PhoneNumber");
        ds.Tables[0].Rows.Add();
        ds.Tables[0].Rows[0][0] = 415;
        ds.Tables[0].Rows[0][1] = 9252222222;
        // output with row iterator
        Console.WriteLine("Using Iteration of DataTable in DataSet");
        foreach (DataRow number in ds.Tables[0].AsEnumerable())
        {
            if (number["AreaCode"].ToString() == CurrentAreaCode)
            {
                Console.WriteLine(number["PhoneNumber"].ToString());
            }
        }
        Console.WriteLine("Press Enter To Continue...");
        Console.ReadLine();
        // output using Linq
        Console.WriteLine("Using Linq");
        Console.WriteLine((from info 
                           in ds.Tables["AreaCodeInformation"].AsEnumerable() 
                           where info.Field<string>("AreaCode") == CurrentAreaCode 
                           select info.Field<string>("PhoneNumber")).FirstOrDefault());
        Console.ReadLine();
    }
  
