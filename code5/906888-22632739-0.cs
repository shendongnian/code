    namespace CopyExcel
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fileName = string.Format("{0}\\MaintList.xlsx", "C:\\Import");
                var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);
                var db = new ModulesDataContext();
                var adapter = new OleDbDataAdapter("SELECT * FROM [WCR$]", connectionString);
                var ds = new DataSet();
                adapter.Fill(ds, "ExcelData");
                DataTable ExcelData = ds.Tables["ExcelData"];
                var counter = 0;
                foreach (DataRow row in ExcelData.Rows)
                {
                    Module mod = new Module();
                    
                    mod.SystemID = Convert.ToInt32(ExcelData.Rows[counter]["SysID"]);
                    mod.Module1 = ExcelData.Rows[counter]["Num"].ToString();
                    mod.Title = ExcelData.Rows[counter]["Title"].ToString();
                    mod.Type = "CAI";
                
                    db.Modules.InsertOnSubmit(mod);
                    db.SubmitChanges();
                    counter++;
                }
            }
        }
    }
