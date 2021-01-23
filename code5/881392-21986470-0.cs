    public static void WriteToExcelFolderAccess(Employee empl)
    {
        try
        {
            string[] cellVal = new string[lastRowFold];
            for (int k = 1; k <= lastRowFold; k++)
            {
                string str = mySheetFold.UsedRange.Cells[k, 1].Text;
                cellVal[k - 1] = str;
            }
            var temp = new List<string>();
            foreach (string val in cellVal)
            {
                if (!string.IsNullOrEmpty(val))
                    temp.Add(val);
            }
            cellVal = temp.ToArray();
                
            for (int i = 3; i <= lastRowFold; i++)
            {
                if (mySheetFold.Cells[i, 1].Text == cellVal[empl.CompanyIndex].ToString())
                {
                    MessageBox.Show("found it");
                    int found = i;
                    empl.CompanyIndex += 1;
                    for (int j = i; j <= lastRowFold; j++)
                    {
                        if (empl.CompanyIndex < cellVal.Length)
                        {
                            if (mySheetFold.Cells[j, 1].Text == cellVal[empl.CompanyIndex].ToString())
                            {
                                MessageBox.Show("insert row above");
                                excel.Range rng = mySheetFold.Cells[j, 1];
                                excel.Range row = rng.EntireRow;
                                row.Insert(excel.XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
                                mySheetFold.Range[mySheetFold.Cells[found, 1], mySheetFold.Cells[j, 1]].Merge();
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("insert row below");
                            excel.Range rng = mySheetFold.Cells[j, 1];
                            excel.Range row = rng.EntireRow;
                            row.Insert(excel.XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
                            mySheetFold.Range[mySheetFold.Cells[found, 1], mySheetFold.Cells[j+1, 1]].Merge();
                            break;
                        }
                    }
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            folderAccessList.Save();
            folderAccessList.Close();
        }
    }
