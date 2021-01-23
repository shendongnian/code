     public void GenerateTestData_Book()
        {
        string csv_file_path = GetAppSettingsEntry("CSVResourcesPath", true);
        DataTable csvData = GetDataFromCSVFile(csv_file_path);
        bool hasError = false;
        for (int i = 0; i < csvData.Rows.Count; i++)
        {
            try
            {
                //do your stuff here....
            }
            catch (System.Exception)
            {
                hasError = true;
            }
        }
        Assert.IsFalse(hasError);
    }
