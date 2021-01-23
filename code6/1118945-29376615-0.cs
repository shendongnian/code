    private void button2_Click(object sender, EventArgs e)
    {
         using (StreamReader reader = new StreamReader (@"F:\test.txt"))
         {
             bool content = false; 
             while ((line = reader.ReadLine()) != null)
             {
                if (line.Contains("[1]"))
                {
                    content = true;
                    // You only need this continue if this is on a line by itself
                    continue;
                }
                if (content == true)
                {
                    // The Replace should remove your tags and add what's left to the RichTextBox
                    txtContent.AppendText(line.Replace("[1]", "").Replace("[/1]", ""));
                }
                if(line.Contains("[/1]"))
                {
                    content = false;
                    break; 
                }
            }
        }
    }
 
