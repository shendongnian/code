            private void Form1_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Column1");
                dt.Columns.Add("Column2");
                dt.Columns.Add("Column3");
                dt.Rows.Add(3, 1,35);
                dt.Rows.Add(1, 3, 62);
                BindingSource s = new BindingSource();
                s.DataSource = dt;
                this.dataGridView1.DataSource = s;
                Binding b = new Binding("Text", s, "Column3");
                b.Format += new ConvertEventHandler(b_Format);
                textBox1.DataBindings.Add(b);
            }
    
            void b_Format(object sender, ConvertEventArgs e)
            {
                e.Value = e.Value.ToString() + " USD";
            }
