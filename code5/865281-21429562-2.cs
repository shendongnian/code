    DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
    ServiceController sc
    foreach(DataRow d in dt.Rows)
    {
     string instance = dr["InstanceName"].ToString();
     sc = new ServiceController("MSSQLFDLauncher$"+instance );
     
     switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    Console.WriteLine("MSSQLFDLauncher for" + instance + "is Running");
                    break;
                default:
                    Console.WriteLine("MSSQLFDLauncher for" + instance + "is NOT Running");
                    break;
            }
    }
