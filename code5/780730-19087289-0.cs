        OracleDataReader reader = Command.ExecuteReader())
        {
         reader.Read();
        
        string[] split = reader[0].ToString().Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
         foreach (string line in split)
        {
         if(line.Trim()==")")
        richTextBox1.AppendText(line.Trim() + ";" + Environment.NewLine);
         else
      richTextBox1.AppendText(line.Trim() + Environment.NewLine);
        }  
        }
