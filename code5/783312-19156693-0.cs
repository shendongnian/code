    Test test = new Test(); // This is your instance
    IList<Test> myList = new List<Test>();
    
    foreach (DataRow dataRow in dataTable.Rows)
    {
        // Here you change the values of the existing instance each time you loop
        test.PatientID = Convert.ToInt64(dataRow.ItemArray[0]);
        test.LastName = dataRow.ItemArray[1].ToString();
        test.FirstName = dataRow.ItemArray[2].ToString();
        myList.Add(test); // but you are still just adding the same reference to the list multiple times
    }
