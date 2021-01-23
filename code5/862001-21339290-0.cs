            SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT * FROM DATOST", conn);
            da.Fill(ds, "DATOST");
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "REmove";
            col.Name = "MyButton";
            dataGridView1.Columns.Add(col);
            dtgLista.DataSource = ds.Tables[0].DefaultView;
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.CellContentClick);
