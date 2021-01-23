        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                //Use an async method when there is one available
                string stdNo;
                using (var reader = File.OpenText("Words.txt"))
                {
                    stdNo = await reader.ReadToEndAsync();
                }
                stdNo = stdNo.Replace(Environment.NewLine, ",");
                const string cs = @"what ever";
                MySqlConnection conn = new MySqlConnection(cs);
                MySqlDataAdapter SQLDataAdapter = new MySqlDataAdapter(); ;
                DataSet ds = new DataSet();
                //Use Task.Run to call a long running code on another thread
                //If available you should use await conn.OpenAsync();
                await Task.Run(() => conn.Open());
                //You don't need invoke, after an await you are back to the synchronization context
                textBox1.AppendText(string.Format("MySQL version : {0};", conn.ServerVersion));
                DataTable dt = new DataTable("StudentNamesAndNumbers");
                dt.Columns.Add("Student Name", typeof(string));
                dt.Columns.Add("Student ID", typeof(string));
                dt.Columns.Add("First", typeof(float));
                dt.Columns.Add("Second", typeof(float));
                dt.Columns.Add("Section", typeof(string));
                ds.Tables.Add(dt);
                //...
            }
            finally
            {
                button1.Enabled = true;
            }
        }
