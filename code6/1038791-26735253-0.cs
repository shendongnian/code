    double seconds = dataGridView1.Rows
        .Cast<DataGridViewRow>()
        .AsEnumerable()
        .Sum(x => TimeSpan.Parse((x.Cells["Horas"].Value.ToString())).TotalSeconds);
    TimeSpan totalTime = TimeSpan.FromSeconds(seconds);
    string somat = totalTime.ToString(@"hh\:mm");
