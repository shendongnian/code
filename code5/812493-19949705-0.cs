    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace daoTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // required COM reference: Microsoft Office 14.0 Access Database Engine Object Library
                var dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
                Microsoft.Office.Interop.Access.Dao.Database db = dbe.Workspaces[0].OpenDatabase(@"C:\Users\Public\Database1.accdb");
                Microsoft.Office.Interop.Access.Dao.Field fld = db.TableDefs["myTable"].Fields["oldFieldName"];
                fld.Name = "newFieldName";
                db.Close();
            }
        }
    }
