    private void btnrgt_Click(object sender, EventArgs e)
    {
         DataRowView x = listBox1.SelectedItem as DataRowView;
         if ( x != null)
         {
              string source = x"NameOfTheColumnDisplayed".ToString();
              if(!listbox2.Items.Cast<string>().Any(x => x == source))
              {
                  listbox2.Items.Add(source);
                  txttestno.Text = listBox2.Items.Count.ToString();
              }
         }
    }
