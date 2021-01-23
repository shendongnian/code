           DataTable dt = new DataTable();
           dt.Columns.Add("date");
           dt.Columns.Add("name");
           dt.Columns.Add("info");
           dt.Columns.Add("id");
            for (Loop through your records)
            {
                dr = dt.NewRow();
                dr[0] = ....; // your code here
                dr[1] = ....;
                dr[2] = ....;
                dr[3] = ....;
                dt.Rows.Add(dr); // now put row in table 
            Form2 f2 = new Form2();
            f2.Show();
            f2.dataGridView1.DataSource = dt; 
