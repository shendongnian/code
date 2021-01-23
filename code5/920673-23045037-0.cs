        // Before you press the button copy some excel cells!
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("one", "one");
            dataGridView1.Columns.Add("two", "two");
            dataGridView1.Columns.Add("three", "three");
            dataGridView1.Columns.Add("four", "four");
            dataGridView1.Columns.Add("five", "five");
            dataGridView1.Rows.Add(5);
            dataGridView1.Focus();
            dataGridView1.CurrentCell = dataGridView1[1, 1];
            string s = Clipboard.GetText();
            string[] lines = s.Replace("\n", "").Split('\r');
            string[] fields;
            int row = 0;
            int column = 0;
            foreach (string l in lines)
            { 
                fields = l.Split('\t');
                foreach (string f in fields)
                    dataGridView1[column++, row].Value = f;
                row++;
                column = 0;
            }
        }
