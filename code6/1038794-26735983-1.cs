    TimeSpan all = New TimeSpan(0);
    foreach( DataGridViewRow dgvr In dataGridView1.Rows)
    {
        all = all.Add(TimeSpan.Parse(dgvr.Cells["Horas"].Value.ToString()));
    }
    string somat = all.ToString(@"hh\:mm");
    
