        string fileLoc = @"D:\MyWork\DemoEpub\" + textBox1.Text + ".txt";
        if (!File.Exists(fileLoc))
        {
            using (StreamWriter sw = new StreamWriter(File.Create(fileLoc)))
            {
                
                   
                        try
                        {
                            sw.Write("<START>\n<TITLE>" + textBox1.Text + "</TITLE>\n<BODY>\n<P>PAGE " + textBox2.Text + "</P>\n<P>\n" + richTextBox1.Text + "</P>\n</BODY>\n<END>");
                        }
                        catch(System.IO.IOException exp)
                        {
                            sw.Close();
                        }
                    
                
            }
        }
    }
