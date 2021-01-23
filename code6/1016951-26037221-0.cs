    private void ReadAndFileter1()
        {
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader("file.txt"))
                {
                    string line;
                    string[] array;
                    int rowcount = 0;
                    decimal number;
                    string[] separators = { "\t", " " };
                    int columnCount = 1;
                    string[] lines = File.ReadAllLines("file.txt");
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("VENTURA SECURITIES LIMITED (NSE F&O)")) continue;
                        if (lines[i].Contains("ALL EXCHANGES DERIVATIVES CLIENTWISE STATEMENT AS ON 16-05-2012")) continue;
                        if (lines[i].Contains("-------------------------------------------------------")) continue;
                        
                        array = lines[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        if (array[0] == "PARTY" || array[0] == "") continue;
                        dataGridView1.Rows.Add();
                        foreach (string str in array)
                        {
                            if (Decimal.TryParse(str, out number))
                            {
                                dataGridView1.Rows[rowcount].Cells[columnCount++].Value = number;
                            }
                        }
                        dataGridView1.Rows[rowcount].Cells[0].Value = array[0];
                        rowcount++;
                        columnCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
