        using System.IO;
        using System.Windows.Forms;
        using System.Data;
        public class readCSV
        {
        public DataTable getDataTable()
        {
            DataTable dTable = new DataTable();
            try
            {
                using (StreamReader readFile = new StreamReader(this.filename))
                {
                    string line;
                    string[] row;
                    int rowcount = 0;
                    DataRow dRow;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        dRow = dTable.NewRow();
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (rowcount == 0)
                            {
                                dTable.Columns.Add(row[i]);
                            }
                            else
                            {
                                dRow[dTable.Columns[i]] = row[i];
                            }
                        }
                        if (rowcount != 0)
                        {
                            dTable.Rows.Add(dRow);
                        }
                        rowcount++;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dTable;
        }
        }
