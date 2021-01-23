    using(StreamReader sr = new StreamReader(filename)
    {
        StringBuilder sb = new StringBuilder();
        While(sr.Peek() >-1)
        {
             sb.Append(   sr.ReadLine() );
        }
    
        The_Textbox.Text = sb.ToString();
    }
