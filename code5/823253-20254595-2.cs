    public static void ConditionallyCreateTables()
    {
        const string sdfPath = @"\Program Files\duckbilled\Platypus.sdf";
        string dataSource = string.Format("Data Source={0}", sdfPath);
    
        if (!File.Exists(sdfPath))
        {
            using (var engine = new SqlCeEngine(dataSource))
            {
                engine.CreateDatabase();
            }
        }
        using (var connection = new SqlCeConnection(dataSource))
        {
            connection.Open();
            using (var command = new SqlCeCommand())
            {
                command.Connection = connection;
    
                if (!TableExists(connection, "InventoryItems"))
                {
                    command.CommandText = "CREATE TABLE InventoryItems (Id nvarchar(50) NOT NULL, PackSize smallint NOT NULL, Description nvarchar(255), DeptDotSubdept numeric, UnitCost numeric, UnitList numeric, UPCCode nvarchar(50), UPCPackSize smallint, CRVId int);";
                    command.ExecuteNonQuery();
                }
    
                if (!TableExists(connection, "Departments"))
                {
                    command.CommandText = "CREATE TABLE Departments (Id int NOT NULL, DeptNum int NOT NULL, DepartmentName nvarchar(255))";
                    command.ExecuteNonQuery();
                }
    
                if (!TableExists(connection, "Subdepartments"))
                {
                    command.CommandText = "CREATE TABLE Subdepartments (Id int NOT NULL, DeptId int NOT NULL, SubdeptId int NOT NULL, DepartmentName nvarchar(255))";
                    command.ExecuteNonQuery();
                }
    
                if (!TableExists(connection, "Redemptions"))
                {
                    command.CommandText = "CREATE TABLE Redemptions (Id int NOT NULL, RedemptionId nvarchar(50), RedemptionItemId nvarchar(50), RedemptionName nvarchar(255), RedemptionAmount numeric, RedemptionDept nvarchar(50), RedemptionSubdept nvarchar(50))";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
