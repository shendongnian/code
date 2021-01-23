    List<TextBox> allTextBoxes = this.Controls.OfType<TextBox>().ToList();
    int current = -1;
    using (var con = new MySqlConnection(Properties.Settings.Default.ConnectionString))
    {
        using (var cmd = new MySqlCommand("SELECT ColumnName FROM dbo.TableName", con))
        {
            con.Open();
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read() && ++current < allTextBoxes.Count)
                {
                    allTextBoxes[current].Text = rd.GetString(0);
                }
            }
        }
    }
