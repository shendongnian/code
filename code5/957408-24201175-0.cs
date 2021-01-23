    StreamWriter sw=new StreamWriter(path,true);
    private void button5_Click(object sender, EventArgs e)
            {  try
               { 
                int a = Int32.Parse(textBox1.Text);
                ///...
                }
                catch (Exception ex)
                {
                   sw.WriteLine(ex.Message);
                }
             }
 
