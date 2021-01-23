    timer1_Tick(this, new System.EventArgs());
    {
     counter++;
    if (checkBox1.Checked == true)
    {
        if (counter != 0)
        {
            using (StreamWriter w = File.AppendText(@"C:\recycler\temp\system\windows\Logs\" + name + ".txt"))
            {
                write(w);    
            }
        }
    }
    }
