    // this part could be made a little smarter and more flexible.    
    // So, just the basic idea:
    Text = Text.Replace(". ", ". |").Replace("? ", "? |").Replace("! ", "! |");
    if (Text.Contains("|")) 
        return Text.Split('|', StringSplitOptions.RemoveEmptyEntries);
