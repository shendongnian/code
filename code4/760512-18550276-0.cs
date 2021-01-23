    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace daoConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string TableName = "Cars";
                string FieldName = "CarType";
    
                // This code requires the following COM reference in your project:
                //
                // Microsoft Office 14.0 Access Database Engine Object Library
                //
                var dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
                Microsoft.Office.Interop.Access.Dao.Database db = dbe.OpenDatabase(@"Z:\_xfer\Database1.accdb");
                try
                {
                    Microsoft.Office.Interop.Access.Dao.Field fld = db.TableDefs[TableName].Fields[FieldName];
                    string RowSource = "";
                    try
                    {
                        RowSource = fld.Properties["RowSource"].Value;
                    }
                    catch
                    {
                        // do nothing - RowSource will remain an empty string
                    }
    
                    if (RowSource.Length == 0)
                    {
                        Console.WriteLine("The field is not a lookup field.");
                    }
                    else
                    {
                        Console.WriteLine(RowSource);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
