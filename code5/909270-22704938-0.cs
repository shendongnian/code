            DataTable dtGridView = new DataTable();
            //dates, room id, quantity, price
            dtGridView.Columns.Add("dates", typeof(string));
            dtGridView.Columns.Add("room_id", typeof(int));
            dtGridView.Columns.Add("quantity", typeof(int));
            dtGridView.Columns.Add("price", typeof(double));
            dtGridView.Rows.Add(new object[] { "3/28/2014", 1, 11, 150 });
            dtGridView.Rows.Add(new object[] { "3/27/2014", 1, 5, 160 });
            dtGridView.Rows.Add(new object[] { "3/21/2014", 2, 6, 300 });
            dtGridView.Rows.Add(new object[] { "3/20/2014", 3, 9, 70 });
            dataGridView1.DataSource = dtGridView;
