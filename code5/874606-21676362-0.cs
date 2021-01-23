     range = sheet.UsedRange;
                        // leer las celdas
                        int rows = range.Rows.Count;
                        int cols = range.Columns.Count;
                        for (int row = 1; row <= rows; row++)
                        {
                            for (int col = 1; col <= cols; col++)
                            {
                                if (!(range.Cells[row, col].Value == null))
                                {
                                    string valorBar = range.Cells[row, col].Formula.Replace(@"C:\", @"C:\Gestion\");
                                    range.Cells[row, col].Formula = valorBar;
                                    Console.WriteLine(valorBar);
                                }
                            }
                        }
