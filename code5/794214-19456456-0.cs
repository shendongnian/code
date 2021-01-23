    System.IO.StreamReader sr = new System.IO.StreamReader("fileYouHaveSavedTheScore.txt");
    if(Convert.ToInt32(sr.ReadLine())<Convert.ToInt32(this.label1.Text)
    {
        sr.Close();
        using(System.IO.StreamWriter sw=new StreamWriter("fileYouHaveSavedTheScore.txt",false))
            sw.WriteLine(this.label1.Text);
    }
