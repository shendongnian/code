    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    
    namespace ExcelExport
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                //Create a connection to the database
                SqlConnection conn = new SqlConnection("user id=username;" +
                                                       "password=password;server=SQL-04;" +
                                                       "Trusted_Connection=yes;" +
                                                       "database=JOHN; " +
                                                       "connection timeout=30");
                conn.Open();
                //Set up the SQL query
                string query = args[0];
                SqlCommand cmd = new SqlCommand(query, conn);
    
                //Fill a C# dataset with query results
                DataTable t1 = new DataTable();
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(t1);
                }
    
                //Assign filename to a variable
                string filePath = args[1];
    
                var file = new FileInfo(filePath);
    
                //Load the data table into the excel file and save
                using (ExcelPackage pck = new ExcelPackage(file))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Data");
                    ws.Cells["A1"].LoadFromDataTable(t1, true);
                    pck.Save();
                }
    
                //Close the existing connection to clean up
                conn.Close();
            }
        }
    }
