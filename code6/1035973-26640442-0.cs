    using System.IO;
    using System.Text.RegularExpressions;
    
    if (ofd.ShowDialog() == DialogResult.OK)
    {
        string withoutQuotes = Regex.Replace(File.ReadAllText(ofd.FileName), "\"", "");
        File.WriteAllText(ofd.FileName, withoutQuotes);
    }
