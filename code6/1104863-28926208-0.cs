    public static bool SaveDataTableToExcel(DataTable table, string savePath)
        {
            //open file
            StreamWriter wr = new StreamWriter(savePath, false, Encoding.Unicode);
            try
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    wr.Write(table.Columns[i].ToString().ToUpper() + "\t");
                }
                wr.WriteLine();
                //write rows to excel file
                for (int i = 0; i < (table.Rows.Count); i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (table.Rows[i][j] != null)
                        {
                            wr.Write("=\"" + Convert.ToString(table.Rows[i][j]) + "\"" + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
            return true;
        }
