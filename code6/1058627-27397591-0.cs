    if(System.IO.File.Exist(textBox1.Text))
    {
     System.Diagnostics.Process.Start(textBox1.Text)
    }
    else
    {
      //File Not Found
    }
