    private void todayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataView dv = _dataSource.Tables[0].DefaultView;    //have a temp dataview to filter data in
            DateTime date = new DateTime();
            date = DateTime.Today;
            
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            string expression = date.Year.ToString() + "-" + 
                date.Month.ToString() + "-" + date.Day.ToString();
            
            
            dv.RowFilter = string.Format("thedate = #{0}#", expression);
            _tableNameBS.DataSource = dv;
            dataGridView1.DataSource = _tableNameBS;
        }
