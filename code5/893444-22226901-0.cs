      private void BuildCommand()
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("You must fill out text box 1");
                    return;
                }
    
                var sb = new StringBuilder();
    
                sb.AppendLine("select column1, column2, column3");
                sb.AppendLine("from MyTableName");
                sb.AppendLine("Where");
                sb.AppendLine(textBox1.Text);
    
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    sb.AppendLine(textBox2.Text);    
                }
    
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    sb.AppendLine(textBox3.Text);
                }
    
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    sb.AppendLine(textBox4.Text);
                }
            }
