        const int lastN = 21;
        int[] minutesMax = new int[lastN];
        int[] minutesMin = new int[lastN];
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < lastN; i++)
            {
                minutesMax[i] = i;
            }
            for (int i = 1; i < lastN; i++)
            {
                minutesMin[i] = (i*10);
            }
            GridBind();
        }
        void GridBind()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Max");
            dt.Columns.Add("Min");
            for (int i = 0; i < minutesMax.Length; i++)
            {
                DataRow dRow = dt.NewRow();
                dRow["Max"] = minutesMax[i];
                dRow["Min"] = minutesMin[i];
                dt.Rows.Add(dRow);
            }
            dataGridView1.DataSource = dt;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            minutesMin[0] = 10000;
            GridBind();
        }
