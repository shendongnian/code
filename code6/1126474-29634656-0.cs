    private void button1_Click(object sender, EventArgs e)
    {
        string translatedtext = richTextBox1.Text;//Text property is already a string 
                                                 //no need to add ToString()
     
        foreach(character in translatedtext)
        {
            if(character == 'a')
            {
                //Do something with character
            }
            
        }
     }
