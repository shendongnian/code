    public void FilenameHasWord(string filename, string word)
    {   
        Boolean red = filename.Contains(word);
        if (red == true)
        {
            MessageBox.Show(" the filename contains the word");
        }
        else
        {
            MessageBox.Show(" the filename does not contain the word");
        }
     }
     private void button2_Click(object sender, EventArgs e)
     {
        string filename = textBox1.Text;
        string word = textBox2.Text;
        FilenameHasWord(filename, word);
     }    
