    public void RemoveWord(string word){
      Regex reg = new Regex("(ALTER TABLE .+ REFERENCES\\s+)\"" + word + "\"[.](.+)");
      richTextBox1.Text = reg.Replace(richTextBox1.Text, "$1$2"); 
    }
    //To remove USER1, do this
    RemoveWord("USER1");
    //To remove USER2, do this
    RemoveWord("USER2");
    
