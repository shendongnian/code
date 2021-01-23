        DataGridViewColumn col = new DataGridViewColumn();
        col.HeaderText = "Age";
        col.Name = "ageBoD";
        dataGridViewX1.ReadOnly = true;  // This should change it to allow for expansion.
        int colIndex = dataGridViewX1.Columns.Add(col);
    
        DateTime brithday;
        for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
        {
            brithday = (DateTime)dataGridViewX1[3, i].Value;
            TimeSpan age = DateTime.Now - brithday;
            dataGridViewX1[17, i].Value = age.Days / 365;
        }
        dataGridViewX1.ReadOnly = false;  // This will change it back.
