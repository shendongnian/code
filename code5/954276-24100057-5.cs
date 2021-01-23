    protected void FileContentUpdate_Click(object sender, EventArgs e)
    {
        string filePath = @"F:\Stackoverflow\24099577\DomManipulation.aspx";
        string[] content = File.ReadAllLines(filePath);
        for (int i = 0; i < content.Length; i++) 
        {
            content[i] = content[i].Replace("<p id='updateBox'></p>", "<br/> <h3>" + headertambahan.Text + "</h3> <p style=\"font-size:12px; font-weight:normal;\">" + isitambahan.Text + "</p>");
        }
        File.WriteAllLines(filePath, content);
    }
