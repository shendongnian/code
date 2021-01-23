    Paragraph p = new Paragraph();
    p.Inlines.Add("Plase visit ");
    var link = new Hyperlink();
    link.Inlines.Add("google.com ");
    p.Inlines.Add(link);
    p.Inlines.Add("to continue");
    rtb.Blocks.Add(p);
