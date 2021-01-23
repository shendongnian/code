    String searchVal = textBox1.Text.Trim();
    bool firstDisplayed = false;
    for (int i = 0; i < dataGridView2.RowCount; i++)
    {
       if (dataGridView2.Rows[i].Cells[0].Value != null && dataGridView2.Rows[i].Cells[0].Value.ToString().Contains(searchVal))
       {
          if (firstDisplayed == false)
          {
             dataGridView2.FirstDisplayedScrollingRowIndex = i;
             firstDisplayed = true;
          }
          dataGridView2.Rows[i].Selected = true;
       }
    }
