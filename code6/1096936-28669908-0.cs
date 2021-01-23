    string text = dataGridView1.Rows[i].Cells[3].Value.ToString();
    Decimal value=0;
    if (Decimal.TryParse(text.Replace(',', '.'), out value))
    {
       //parse success
       dataGridView1.Rows[i].Cells[3].Value = value.ToString() + " $"; // put the correct value
    }
    else {
       //parse not success 
       dataGridView1.Rows[i].Cells[3].Value ="- $"; // Put something which allow you to identify the issue.
     }
