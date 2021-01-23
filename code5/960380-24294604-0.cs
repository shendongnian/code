    DataTable dt;
    private void button1_Click(object sender, EventArgs e)
    {
         dt = new DataTable();
         ParseCSVFile("day1.csv");
         ParseCSVFile("day2.csv");
         dataGridView1.DataSource = dt;            
    }
    private void ParseCSVFile(string sFileName)
    {
        var dIndex = new Dictionary<string, int>();
        using (TextFieldParser csvReader = new TextFieldParser(sFileName))
        {                
            csvReader.Delimiters = new string[] { "," };
            var colFields = csvReader.ReadFields();
            for (int i = 0; i < colFields.Length; i++)
            {
                string sColField = colFields[i];
                if (sColField != string.Empty)
                {
                    dIndex.Add(sColField, i);
                    if (!dt.Columns.Contains(sColField))
                       dt.Columns.Add(sColField);
                }
            }
            while (!csvReader.EndOfData)
            {
                 string[] fieldData = csvReader.ReadFields();
                 if (fieldData.Length > 0)
                 {
                     DataRow dr = dt.NewRow();
                     foreach (var kvp in dIndex)
                     {
                         int iVal = kvp.Value;
                         if (iVal < fieldData.Length)
                             dr[kvp.Key] = fieldData[iVal];
                     }
                     dt.Rows.Add(dr);
                  }                  
              }
          }
      }
