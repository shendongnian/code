    IList<Test> myList = new List<Test>();
    
    foreach (DataRow dataRow in dataTable.Rows)
    {
        Test test = new Test(); // Each loop iteration will now create a new instance of Test
        test.PatientID = Convert.ToInt64(dataRow.ItemArray[0]);
        test.LastName = dataRow.ItemArray[1].ToString();
        test.FirstName = dataRow.ItemArray[2].ToString();
        myList.Add(test);
    }
