    StringBuilder sb = new StringBuilder();
    sb.Append("<script>");
    // Store transmission chrome feature.
    for (int i = 0; i < Transmission.Length; i++)
    {
        sb.Append("var obj = {text: '")
            .Append(Escape(Transmission[i][0]))
            .Append("',")
            .Append("value: '")
            .Append(Escape(Transmission[i][1]))
            .Append("'};")
            .Append("transChromeData.push(obj);");
    }
    sb.Append("</script>");
    this.RegisterStartupScript("Info", sb.ToString());
    ...
    static string Escape(string source)
    {
        return source.Replace(@"'",  @"\'");
    }
