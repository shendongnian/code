    // this part could use RegeEx for more performance and flexibility. 
    // Right now it requires a space after the last "."
    // So, just the basic idea:
    Text = Text.Replace(". ", ". |").Replace("? ", "? |").Replace("! ", "! |");
    if (Text.Contains("|")) 
        return Text.Split('|', StringSplitOptions.RemoveEmptyEntries);
