    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Data;
    using System.Data.OleDb;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ConsolidateAccProdExcel
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sheetPath = @"PATH-TO-FILE";
                string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=\"Excel 12.0 Macro;HDR=YES;IMEX=1\"",sheetPath);
    
                Dictionary<string, Dictionary<string, string>> relationshipDictionary = new Dictionary<string, Dictionary<string, string>>();
    
                using (OleDbConnection oleConnection = new OleDbConnection(connectionString))
                {
                    oleConnection.Open();
                    System.Data.DataTable dt = oleConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
                    List<DataTable> listDt = new List<DataTable>();
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listDt.Add(GetWorksheetData(oleConnection, (string)dt.Rows[i]["TABLE_NAME"]));
                    }
    
                    List<DataRow> rowList = new List<DataRow>();
    
                    for (int i = 0; i < listDt.Count; i++)
                    {
                        DataColumnCollection dtColumns = listDt[i].Columns;
                        foreach (DataRow drRow in listDt[i].Rows)
                        {
                            if (!(drRow.ItemArray[0] is DBNull))
                            {
                                Dictionary<string, string> accessoryData = new Dictionary<string, string>();
                                string rowName = (string)drRow.ItemArray[0];
                                for (int j = 1; j < drRow.ItemArray.Length; j++)
                                {
                                    if ((string)drRow.ItemArray[j].ToString() != 0.ToString()) accessoryData.Add(dtColumns[j].ColumnName, (string)drRow.ItemArray[j].ToString());
                                }
                                try { relationshipDictionary.Add(rowName, accessoryData); }
                                catch (ArgumentException e) { Trace.WriteLine("problem: " + rowName); }
                            }
                        }
                    }
    
                    writeConcatenatedSheets(relationshipDictionary, oleConnection);
                }
    
                long relationshipsCount = 0;
    
                foreach (KeyValuePair<string, Dictionary<string, string>> product in relationshipDictionary)
                {
                    relationshipsCount += product.Value.Count;
                }
                Trace.WriteLine(relationshipsCount);
    
            }
    
            private static void writeConcatenatedSheets(Dictionary<string, Dictionary<string, string>> relationshipDictionary, OleDbConnection connection)
            {
                int relationshipsCount = 0;
    
                foreach (KeyValuePair<string, Dictionary<string, string>> product in relationshipDictionary)
                {
                    relationshipsCount += product.Value.Count;
                }
    
                int currentCount = 1;
                string writeCommand = "";
    
                Excel.Application app = new Excel.Application();
                app.Visible = true;
    
                Excel.Workbook workbook = app.Workbooks.Open(@"PATH-TO-FILE");
                Excel.Sheets excelSheets = workbook.Worksheets;
    
                Excel.Worksheet consolidateSheet = (Excel.Worksheet)excelSheets.get_Item("Consolidated Data");
    
                Excel.Range rows = consolidateSheet.Rows;
    
                int count = rows.Count;
                
                foreach (KeyValuePair<string, Dictionary<string, string>> product in relationshipDictionary)
                {
                    int productCount = 0;
                    foreach (KeyValuePair<string, string> accessory in product.Value)
                    {
                        string[,] values = new string[1,4];
                        values[0,0] = product.Key + "_[" + productCount + "]";
                        values[0,1] = product.Key;
                        values[0,2] = accessory.Key;
                        values[0,3] = accessory.Value;
    
                        rows.get_Range("A" + currentCount, "D" + currentCount).Value2 = values;
                        ++productCount;
                        ++currentCount;
                    }
                }
    
                connection.Close();
            }
    
            private static DataTable GetWorksheetData(OleDbConnection oleConnection, string SheetName)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter odba = new OleDbDataAdapter(string.Format ("SELECT * FROM [{0}]",SheetName), oleConnection);
                odba.Fill(dt);
                return dt;
            }
        }
    }
:)
