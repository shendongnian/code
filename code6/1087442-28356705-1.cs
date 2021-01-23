    private void Form1_Load(object sender, EventArgs e)
    {
       StreamReader sr = new StreamReader("setting.txt");
       string line;
       int n=0;
       while(!sr.EndOfStream)
       {
         line = sr.ReadLine();
         
         if(String.Equals(line, "true"))
         {
            dataGridView1.Columns[n++].Visible = true;
         }
         else if(String.Equals(line, "false"))
         {
            dataGridView1.Columns[n++].Visible = false;
         }
       }
       
       sr.Close();
    }
