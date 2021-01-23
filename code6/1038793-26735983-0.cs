    TimeSpan all = New TimeSpan(0);
    foreach( DataGridViewRow dgvr In dataGridView1.Rows)
    {
        TimeSpan temp = TimeSpan.Parse(dgvr.Cells["Horas"].Value.ToString());
        all = all.Add(temp);
    }
    string somat = all.ToString(@"hh\:mm");
    
