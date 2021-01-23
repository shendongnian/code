    if you populate listboxes properly there will be no need to move items
    private void button8_Click(object sender, EventArgs e)
    {
       int limit = 10;
       string[] fileData = File.ReadAllText(@" To-Do References .txt").Split(new string[] { "\r\n" },    StringSplitOptions.RemoveEmptyEntries);
       // this loop adds items to the 1st list until limit is reached
       for(int i =0; i<limit && i<fileData.Length; i++)
          checkedListBox1.Items.Add(fileData[i]);
       // if there extra items, 2nd loop adds them to list №2
       for(int i =limit; i<fileData.Length; i++)
          checkedListBox2.Items.Add(fileData[i]);
    }
