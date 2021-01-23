    If(lineIn[0].ToString() != "")
    {
        dataGridView1.Rows.Add(counter, "1", DateTime.ParseExact(lineIn[0].ToString(), "dd.MM.yyyy", null).ToString("yyyy-MM-dd"), ControlPrice, lineIn[3]);
    }
    else
    {
        dataGridView1.Rows.Add(counter, "1", "", ControlPrice, lineIn[3]);
    }
