        private DataTable ReadFiles(string sourceDir)
        {
            var IcsvFile = Directory.EnumerateFiles(sourceDir, "*.csv");
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Age", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Sex", System.Type.GetType("System.String")); // Gender in proper english 
            dt.Columns.Add("Doctor", System.Type.GetType("System.String"));
            dt.Columns.Add("Mobile", System.Type.GetType("System.String"));
            dt.Columns.Add("Alignment", System.Type.GetType("System.String"));
            dt.Columns.Add("No of medicins", System.Type.GetType("System.String"));
            dt.Columns.Add("Temperature ", Type.GetType("System.Int32"));
            dt.Columns.Add("Blood Pressure", System.Type.GetType("System.String"));
            dt.Columns.Add("Pulse Rate", System.Type.GetType("System.String"));
            dt.Columns.Add("Respiratory Rate", System.Type.GetType("System.Int32"));
            foreach (string currentFile in IcsvFile)
            {
                ImportSingleFile(currentFile, ref dt);
            }
            return dt;
        }
        private void ImportSingleFile(string FilePath, ref DataTable dt)
        {
            string[] Lines = File.ReadAllLines(FilePath);
            string ColumnName, ColumnData;
            int EqualSignIndex, intColumnData;
            DataRow Row = null;
            ColumnName = string.Empty;
            foreach (string Line in Lines)
            {
                EqualSignIndex = Line.IndexOf("=");
                if (EqualSignIndex > -1)
                {
                    ColumnName = Line.Substring(0, EqualSignIndex);
                    // after = there is always , that we don't want in the data, 
                    // and the line sometimes ends with a , that we also don't want
                    ColumnData = Line.Substring(EqualSignIndex + 2).TrimEnd(','); 
                }
                else
                {
                    ColumnData = Line;
                }
                if (ColumnName == "ID")
                {
                    Row = dt.NewRow();
                }
                if (Row != null)
                {
                    if(dt.Columns[ColumnName].DataType == Type.GetType("System.Int32")) {
                        if(int.TryParse(ColumnData, out intColumnData)) 
                        {
                            Row[ColumnName] = intColumnData;
                        } else {
                            throw new InvalidDataException(string.Format("For column {0} an integer value is expected", ColumnName));
                        }
                    } else {
                        Row[ColumnName] = ColumnData;
                    }                   
                }
            }
        }
