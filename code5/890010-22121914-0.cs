    string command = @"select "WorkOrder"."WorkOrderID", "Customer"."FirstName", "Vehicles"."Model", "WorkOrder"."State"  from "WorkOrder", "Customer", "Vehicles" WHERE "WorkOrder"."VIN" = "Vehicles"."VIN" AND "Vehicles"."CustomerID" = "Customer"."CustomerID" AND "WorkOrder"."State" = 'In Progress'";
    using(SqlConnection conn = new SqlConnection(connectionString))
    using(SqlCommand command = conn.CreateCommand())
    {
        command.Connection = conn;
        using(SqlDataAdapter adapter = new SqlDataAdapter())
        {
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridview1.DataSource = table;
            DataGridview1.AutoGenerateColumns = true;
        }
    }
