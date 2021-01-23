    using(var connection = new MySqlConnection("server=localhost;database=test;uid=test;password=test") {
        connection.Open();
        int orderNumber = 0;
        using (var command = connection.CreateCommand()) {
             command.CommandText = @"SELECT label_type, label, quantity FROM system_printserver WHERE print=0";
             DataTable data = new DataTable();
             adapter.Fill(data);
             dataGridView1.DataSource = data;
    
             var reader = command.ExecuteReader();
             printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
    
             if(reader.Read()) {
                 orderNumber = Convert.ToInt32(reader.GetString(1));
             }
        }
    
        using(var command = connection.CreateCommand()) {
            command.CommandText = string.format(@"SELECT id_order, id_carrier FROM ps_orders WHERE id_order={0}",orderNumber);
            var reader =  command.ExecuteReader();
            if(reader.Read()){
                printDocument1.Print();
                return reader.GetString(1);
            }
        }
    }
