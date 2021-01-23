     protected void Page_Load(object sender, EventArgs e)
            {
                DataSet dsresult = new DataSet();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?><list><map><entry key=\"aid\">160608</entry><entry key=\"aDate\">2013-10-24 00:00:00.0 IST</entry><entry key=\"insuranceType\">Self Pay</entry><entry key=\"status\">New</entry><entry key=\"pid\">160576</entry><entry key=\"pChartno\" /><entry key=\"lName\">Mathur</entry><entry key=\"fName\">Gaurav</entry><entry key=\"mName\">mathur</entry><entry key=\"gender\">Male</entry><entry key=\"ssn\" /><entry key=\"providerId\">2030</entry><entry key=\"providerFname\">lakshman</entry></map></list>");
                XmlElement exelement = xml.DocumentElement;
                dsresult.ReadXml(new XmlTextReader(new System.IO.StringReader(exelement.InnerXml)));
    
                DataTable transposedTable = GenerateTransposedTable(dsresult.Tables[0]);
    
                grd.DataSource = transposedTable;
                grd.DataBind();
            }
     private DataTable GenerateTransposedTable(DataTable inputTable)
            {
                DataTable outputTable = new DataTable();
    
                // Add columns by looping rows
    
                // Header row's first column is same as in inputTable
                outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());
    
                // Header row's second column onwards, 'inputTable's first column taken
                foreach (DataRow inRow in inputTable.Rows)
                {
                    string newColName = inRow[0].ToString();
                    outputTable.Columns.Add(newColName);
                }
    
                // Add rows by looping columns        
                for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = outputTable.NewRow();
    
                    // First column is inputTable's Header row's second column
                    newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                    for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                    {
                        string colValue = inputTable.Rows[cCount][rCount].ToString();
                        newRow[cCount + 1] = colValue;
                    }
                    outputTable.Rows.Add(newRow);
                }
    
                return outputTable;
            }
