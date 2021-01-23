    var re = new System.Text.RegularExpressions.Regex(
       @"^http:\/\/(?:www\.)?youtube.com\/watch\?[^?]*v=(\w+)\b[^\s?]*$",
       System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    var match = re.Match(textBox1.Text);
    if (match.Success)
    {
       textBox2.Text = match.Value;
       if (match.Groups.Count > 1)
          textBox3.Text = match.Groups[1].Value;
       else
          textBox3.Text = "Group missing";
    }
    else
    {
       textBox2.Text = "(No match)";
       textBox3.Text = string.Empty;
    }
