    private List<string> ReverseStringFormat(string template, string str) {
        string pattern = <<SOME_PLACE>> .Transmogrify(template);
        Regex r = new Regex(pattern);
        Match m = r.Match(str);
        List<string> ret = new List<string>();
        for (int i = 1; i < m.Groups.Count; i++)
            ret.Add(m.Groups[i].Value);
        return ret;
    }
