    private void btnrgt_Click(object sender, EventArgs e)
    {
         DataRowView x = listBox1.SelectedItem as DataRowView;
         if ( x != null)
         {
              listBox2.Items.Add(x["NameOfTheColumnDisplayed"].ToString());
              txttestno.Text = listBox2.Items.Count.ToString();
         }
    }
