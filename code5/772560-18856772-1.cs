        public static bool WriteCsvFile(string path, DataTable myData)
        {
            if (myData == null)
                return false;
            //Information about the table we read
            int nbRows = myData.Rows.Count;
            int nbCol = myData.Columns.Count;
            StringBuilder stringToWrite = new StringBuilder();
            //We get the headers of the table
            stringToWrite.Append(myData.Columns[0].ToString());
            for (int i = 1; i < nbCol; ++i)
            {
                stringToWrite.Append(",");
                stringToWrite.Append(myData.Columns[i].ToString());
            }
            stringToWrite.AppendLine();
            //We read the rest of the table
            for (int i = 0; i < nbRows; ++i)
            {
                stringToWrite.Append(myData.Rows[i][0].ToString());
                for (int j = 1; j < nbCol; ++j)
                {
                    stringToWrite.Append(",");
                    stringToWrite.Append(myData.Rows[i][j].ToString());
                }
                stringToWrite.AppendLine();
            }
            return WriteCsvFile(path, stringToWrite);
        }
