    private void button1_Click(object sender, EventArgs e)
    {
        string sentence = textBox2.Text;
        string extract = textBox1.Text;        
        string newSentence = sentence.Replace(extract, " ");
        if ( sentence.Contains(extract))
        {   
            textBox3.Text = newSentence.ToUpper(); 
            textBox4.Text = newSentence.Length.ToString();  
                                               
        }
     }
