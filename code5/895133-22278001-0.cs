    private void lbStudents_SelectedIndexChanged(object sender, EventArgs e)
    {
       if(lbStudents.SelectedItem != null)
       {
           decimal result;
           var numbers = lbStudents.SelectedItem.ToString()
           .Split(new [] { '|' }, StringSplitOptions.RemoveEmptyEntries)
           .Where(x => decimal.TryParse(x, out result))
           .ToList();
           txtBox1.Text = numbers[0];
           txtBox2.Text = numbers[1];
           txtBox3.Text = numbers[2];
       }
    }
