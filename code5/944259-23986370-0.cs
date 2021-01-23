        partial void ProcessData_Execute()
        {
            // Write your code here.
            DataWorkspace dataWorkspace = new DataWorkspace();
            Year operation = dataWorkspace.MyData.Years.AddNew();
            dataWorkspace.MyData.SaveChanges();
        }
