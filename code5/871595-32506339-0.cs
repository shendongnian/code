         public void MyGetCSV(DataTable dtRecords,string strReportName)
        {
            string delimiter = ",";
            StringBuilder csvGen = new StringBuilder();
            dtCutOffDate = GetLastMonthEndDate();
            dtFromDate= GetFromDate();
            int index = 0;
            strReportName = string.Format(strReportName, GetTimeFormat(true,dtCutOffDate), GetTimeFormat(false,DateTime.Now));
            string strFilePath = string.Format("{0}{1}", GetReportGenerationPath(), strReportName);
            
            if (!File.Exists(strFilePath))
            {
                File.Create(strFilePath).Close();
            }
            
            foreach (DataColumn column in dtRecords.Columns)
            {
                csvGen.Append(column.ColumnName.ToUpper().Trim()).Append(delimiter);
            }
            index = csvGen.ToString().LastIndexOf(',');
            if (index > 0)
            {
                csvGen = csvGen.Remove(index,1);
            }
            csvGen.Append("\r\n");
            foreach (DataRow row in dtRecords.Rows)
            {
                foreach (DataColumn column in dtRecords.Columns)
                {
                    csvGen.Append(row[column.ColumnName].ToString()).Append(delimiter);
                }
                csvGen.AppendLine();
                index = csvGen.ToString().LastIndexOf(',');
                if (index > 0)
                {
                    csvGen = csvGen.Remove(index, 1);
                }
            }
            File.WriteAllText(strFilePath, csvGen.ToString());
        }
