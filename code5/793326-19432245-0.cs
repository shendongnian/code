    var re = new System.Text.RegularExpressions.Regex(
       @"^http:\/\/(?:www\.)?youtube.com\/watch\?[^?]*v=(\w+)(?=&|$)(?:[^\s?]+)?$",
       System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    var match = re.Match(textBox1.Text);
    if (match.Success)
    {
       if (match.Groups.Count > 1)
          textBox2.Text = match.Groups[1].Value;
       else
          textBox2.Text = "Group missing";
    }
    else
    {
       textBox2.Text = "(No match)";
    }
