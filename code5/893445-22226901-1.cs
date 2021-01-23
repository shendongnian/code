     private void BuildCommand()
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("You must fill out text box 1");
                    return;
                }
    
                var sb = new StringBuilder();
                var sqlparams = new Dictionary<string, string>();
    
                sb.AppendLine("select column1, column2, column3");
                sb.AppendLine("from MyTableName");
                sb.AppendLine("Where");
                sb.AppendLine("param1 = @param1");
                sqlparams.Add("param1", textBox1.Text);
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    sb.AppendLine("and param2 = @param2");
                    sqlparams.Add("param2", textBox2.Text);
                }
    
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    sb.AppendLine("and param3 = @param3");
                    sqlparams.Add("param3", textBox3.Text);
                }
    
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    sb.AppendLine("and param4 = @param4");
                    sqlparams.Add("param4", textBox4.Text);
                }
    
                var cmd = new SqlCommand(sb.ToString());
                foreach (var sqlparam in sqlparams)
                {
                    cmd.Parameters.Add(sqlparam.Key, sqlparam.Value);
                }
            }
