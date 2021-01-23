    private void HideItBtn_Click(object sender, EventArgs e)
    {
        StreamWriter hide = new StreamWriter(HideNameTxt.Text + ".bat");
        hide.WriteLine("@Echo off");
    string[] dirs = Directory.GetDirectories(@"c:\", "p*", SearchOption.TopDirectoryOnly);
        foreach (var dir in dirs)
        {
            hide.WriteLine("attrib " + dir + " +s +h");
         }
         hide.Close();
    }
