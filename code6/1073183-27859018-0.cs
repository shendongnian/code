    var items = currComponent.Split(new string[] { "\r\n", "\n" },
        StringSplitOptions.None);
    
    ScriptingObject.WriteLogMessage("feedback: " 
        + String.Join(". ", items)
        + "<EOF>", true);
    
    if (items.Any(x => x.Contains(attributeDescription))) {
    }
