     string[] words = richTextBox1.Text.Split(' ');       
     foreach (string searchString in words)
     {
          if (richTextBox1.Text.Contains(searchString))
          {
             richTextBox2.AppendText(searchString + " is found.\n");
          }
     }
