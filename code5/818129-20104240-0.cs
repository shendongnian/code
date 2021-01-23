    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    {
        string path = sfd.FileName;
        using (var fs = File.Create(path))
        using (StreamWriter bw = new StreamWriter(fs))
        {
            bw.Write(randomstring);
            bw.Close();
        }
    }
