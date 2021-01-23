    public void button_Click(object sender, EventArgs e)
    {
        using(var sr = new StreamWriter(@"C:\MyFilePath\file.rtf"))
        {
            sr.Write(rtf.Rtf);
        }
    }
