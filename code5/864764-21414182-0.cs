    System.IO.StreamReader file = new System.IO.StreamReader("ais.txt");
    String line;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if ((line = file.ReadLine()) != null)
        {
            listBox1.Items.Add(line);
        }
        else
        {
            timer1.Enabled = false;
            file.Close();
        }
    }
