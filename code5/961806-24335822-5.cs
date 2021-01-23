    SqlCeConnection conn = new SqlCeConnection(@"Data Source=\App_sqlce35\DATA\Database1.sdf");
    SqlCeCommand cmdselect = new SqlCeCommand("select [col0], [col1], [col2], [col3], [col4], [col5], [col6] from tb_histstatus WHERE [col6] <>'';", conn);
    try
    {
        conn.Open();
        SqlCeDataReader res = cmdselect.ExecuteReader();
        List<string> times = new List<string>();
        while (res.Read()) {
            times.Add((string)res.GetValue(6));
        }                
        int[] result = new int[3];
        foreach (string time in times)
        {
            string[] parts = time.Split(':');
            for (int i = 0; i < parts.Length; i++)
            {
                result[i] += Convert.ToInt32(parts[i]);
            }
        }          
        TimeSpan ts = TimeSpan.FromSeconds(result[1] * 60 + result[2]);
        result[0] += ts.Hours; result[1] = ts.Minutes; result[2] = ts.Seconds;
        string resultString = string.Join(":", result);
        MessageBox.Show("Total: " + resultString);
    }
