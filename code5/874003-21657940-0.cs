      // Adds the string if the text box has data in it. 
      private void button1_Click(object sender, System.EventArgs e)
      {
         if(textBox1.Text != "")
         {
            if(checkedListBox1.CheckedItems.Contains(textBox1.Text)== false)
               checkedListBox1.Items.Add(textBox1.Text,CheckState.Checked);  // here you can set CheckState.Indeterminate!
            textBox1.Text = "";
         }
      }
