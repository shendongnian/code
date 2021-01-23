    var list = new List<List<int>>
            {
                new List<int>() {2, 3, 4, 5},
                new List<int>() {2, 3, 4, 5},
                new List<int>() {2, 3, 4, 5},
                new List<int>() {2, 3, 4, 5}
            };
    var columnCount = list[0].Count;
    for (int i = 0; i < columnCount; i++)
    {
         dataGridView1.Columns.Add(i.ToString(),"Column " + i+1);
    }
    for (int k = 0; k < list.Count; k++)
    {
       dataGridView1.Rows.AddCopy(0);
    }
          
    foreach (var item in list)
    {
        for (int k = 0; k < list.Count; k++)
        {
            for (int i = 0; i < item.Count; i++)
            {
                   dataGridView1.Rows[k].Cells[i].Value = item[i];
            } 
        }
     }
