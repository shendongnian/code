    public void EditWebPages()
    {
        foreach(String file in Directory.GetFiles("INSERT_FILES_DIR"))
        {
            String[] lines = File.ReadAllLines(file);
            for(int i=0; i<lines.Length; i++)
                lines[i] = lines[i].Replace(RegexGrab("href=\"(.*?)\"", lines[i]), "../../YOUR/RELATIVE/LINK/");
            File.WriteAllLines(file, lines);
        }
    }
    public static String RegexGrab(String reg, String txt)
    {
        Regex regex = new Regex(reg, RegexOptions.Singleline);
        Match match = regex.Match(txt);
        String str = match.Groups[1].ToString();
        return str;
    }
