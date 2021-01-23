       using Oracle.DataAccess.Client;
       .
       .
       .
       try
        {
            string commands = "select \"WorkOrder\".\"WorkOrderID\", \"Customer\".\"FirstName\", \"Vehicles\".\"Model\", \"WorkOrder\".\"State\"  from \"WorkOrder\", \"Customer\", \"Vehicles\" WHERE \"WorkOrder\".\"VIN\" = \"Vehicles\".\"VIN\" AND \"Vehicles\".\"CustomerID\" = \"Customer\".\"CustomerID\" AND \"WorkOrder\".\"State\" = 'In Progress'";
            using (OracleConnection conn = new OracleConnection("Data Source=rowkir0911;Persist Security Info=True;User ID=xxxx;Password=xxxx;"))
            using (OracleCommand command = new OracleCommand(commands, conn))
            {
                command.Connection = conn;
                conn.Open();
                using (OracleDataAdapter adapter = new OracleDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvDisplayWOs.DataSource = table;
                    dgvDisplayWOs.AutoGenerateColumns = true;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
