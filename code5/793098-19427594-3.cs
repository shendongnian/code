    int current = -1;
    while(name.IndexOf("(") > 0)
    {
        name = name.Substring(name.IndexOf("(") + 1);
    }
    var end = name.IndexOf(")");
    var output = name.Substring(0, end);
    _UILabelPrintName.Text = output;
