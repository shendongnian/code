     public int GetStudentID()
     {
         // The Student ID is the first cell of the current row
         int Row = dataGridView1.CurrentRow.Index;
         return Convert.ToInt32(dataGridView1[0,Row].Value);
     }
     public string GetISBN()
     {
         // The ISBN is the second cell of the current row
         int Row = dataGridView1.CurrentRow.Index;
         return dataGridView1[1,Row].Value.ToString();
     }
