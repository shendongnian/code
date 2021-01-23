    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        var progress = new Progress<string>(update => textBox1.AppendText(update));
        var ds = await Task.Run(() => BackgroundWork(progress));
        dataGridView1.Columns.Clear();
        dataGridView1.DataSource = ds.Tables["StudentNamesAndNumbers"];
        dataGridView1.AutoResizeColumns();
        label1.Text = dataGridView1.Rows.Count.ToString() + " Students";
        button1.Enabled = true;
    }
    private DataSet BackgroundWork(IProgress<string> progress)
    {
        string stdNo = File.ReadAllText("stdNo.txt").Replace(Environment.NewLine, ",");
        const string cs = @"what ever";
        MySqlConnection conn = new MySqlConnection(cs);
        MySqlDataAdapter SQLDataAdapter = new MySqlDataAdapter(); ;
        DataSet ds = new DataSet();
        conn.Open();
        if (progress != null)
            progress.Report(string.Format("MySQL version : {0};", conn.ServerVersion));
        DataTable dt = new DataTable("StudentNamesAndNumbers");
        dt.Columns.Add("Student Name", typeof(string));
        dt.Columns.Add("Student ID", typeof(string));
        dt.Columns.Add("First", typeof(float));
        dt.Columns.Add("Second", typeof(float));
        dt.Columns.Add("Section", typeof(string));
        ds.Tables.Add(dt);
        try
        {
            MySqlCommand SQLcmd = new MySqlCommand();
            SQLcmd = conn.CreateCommand();
            SQLcmd.CommandText = String.Format(@"Select u.firstname as 'Student Name', u.username as 'Student ID'"
                                                    + ",( select  score from gradebook_result g , gradebook_evaluation e "
                                                    + "where g.user_id = u.user_id "
                                                    + "and name = 'First' "
                                                    + "and g.evaluation_id = e.id "
                                                    + "and e.course_code = c.course_code) as 'First' "
                                                    + ",( select  score from gradebook_result g , gradebook_evaluation e "
                                                    + "where g.user_id = u.user_id "
                                                    + "and name = 'Second' "
                                                    + "and g.evaluation_id = e.id "
                                                    + "and e.course_code = c.course_code) as 'Second' "
                                                    + ", c.course_code as 'Section'"
                                                    + "from user u, course_rel_user c "
                                                    + "where "
                                                    + "u.username in ({0}) "
                                                    + "and u.username REGEXP '[0-9]+' "
                                                    + "and c.course_code like 'IT102CPLUS%' "
                                                    + "and  u.user_id = c.user_id ;", stdNo);
            if (progress != null)
                progress.Report(SQLcmd.CommandText);
            SQLDataAdapter = new MySqlDataAdapter(SQLcmd);
            SQLDataAdapter.Fill(dt);
            dt.DefaultView.Sort = "Section ASC, Student Name ASC";
            var lines = new List<string>();
            string[] columnNames = dt.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName).
                                                  ToArray();
            var header = string.Join(",", columnNames);
            lines.Add(header);
            var valueLines = dt.AsEnumerable().Select(row => string.Join(",", row.ItemArray));            
            lines.AddRange(valueLines);
            File.WriteAllLines("Export.csv", lines, Encoding.UTF8);
            return ds;
        }
        catch (MySqlException ex)
        {
            if (progress != null)
                progress.Report(string.Format("Error: {0}\n\n", ex.ToString()));
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
