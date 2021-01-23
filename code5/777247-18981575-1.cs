    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
       if (e.Index >=0 )
       {
          ColorText.ColorListBox(listBox1.Items.Cast<string>().ToList(), e);
       }
    }
