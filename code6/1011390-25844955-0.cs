                            DateTime MyDate;
                        if (!DateTime.TryParse(ExcelDGV.Rows[i].Cells[j].Value.ToString(), out MyDate))
                        {
                            XcelApp.Cells[i + 2, j + 1] = ExcelDGV.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            XcelApp.Cells[i + 2, j + 1] = MyDate;
                        }
