    using System;
    using System.Data.Common;
    using MySql.Data.MySqlClient;
    namesapce MyProg
    {
        class Program
        {
            private const string strMyConnection = "Host=localhost;Database=mydb;User Id=myuser;Password=mypsw";
            static void Main(string[] args)
            {
                using (MySqlConnection myConnection = new MySqlConnection(strMyConnection))
                {
                    using (MyDb.CMyDynaset dyn = new MyDb.CMyDynaset(myConnection, MySqlClientFactory.Instance))
                    {
                        // populate dyn.Table (System.Data.DataTable)
                        dyn.Init("select * from Table");
                        dyn.Load();
                        // access fields
                        foreach (DataColumn column in dyn.Table.Columns)
                        {
                            // ...
                        }
                        // get data
                        long nCountAll = dyn.Table.Rows.Count; // rows count
                        foreach (DataRow row in dyn.Table.Rows)
                        {
                            Object val1 = row[1]; // acess by index
                            Object val2 = row["id"]; // acess by name
                            
                            // ...
                        }
                        // update data
                        dyn.Table.Rows[0]["name"] = "ABC";
                        dyn.Update();
                    }
                }
            }
        }
    }
