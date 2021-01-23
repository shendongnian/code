            private void Form1_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("HomeScore");
                dt.Columns.Add("AwayScore");
                dt.Columns.Add("AwayTeam");
                dt.Rows.Add(3, 1,"Everton");
    
                this.dataGridView1.DataSource = dt;
    
                this.dataGridView1.CellFormatting +=
                    new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            }
    
            void dataGridView1_CellFormatting(object sender,DataGridViewCellFormattingEventArgs e)
            {
                if (e.RowIndex > -1 && e.ColumnIndex == dataGridView1.Columns["AwayTeam"].Index)
                {
                    e.FormattingApplied = true;
                    int home = Convert.ToInt32(dataGridView1["HomeScore", e.RowIndex].Value);
                    int away = Convert.ToInt32(dataGridView1["AwayScore", e.RowIndex].Value);
                    if (home > away)
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
    
                        style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        e.CellStyle = style;
    
                    }
                }
            }
