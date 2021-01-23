    dataGridView1.Columns.Add("Index", "Index");
    dataGridView1.Columns.Add("Value", "Dice Value");
    int[] theData = new int[] { 5, 2, 1, 5, 4, 1, 3, 1};
    
    for (int i = 0; i < theData.Length; i++)
    {
         dataGridView1.Rows.Add(new object[] { i+1, theData[i] });
    }
