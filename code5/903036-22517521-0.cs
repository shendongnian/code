    x = dataGridView1.Rows[0].Cells[1].Value.ToString();
    bool control = true;
    for (int i = 1; i < 10; i++)
    {
       y = dataGridView1.Rows[i].Cells[1].Value.ToString();
       if (x != y) { control = false; break; }
    }
    if(!control)  MessageBox.Show("You cant use your method");
    else changeCellValues();
