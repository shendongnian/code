    var cleanDialogueName = new string(dialogueName.Where(c => char.IsLetterOrDigit(c)).ToArray())
    foreach(var ta in dialogues) 
    {
        var cleanName = new string(ta.name.Where(c => char.IsLetterOrDigit(c)).ToArray())
        print(cleanName + ".." + cleanDialogueName);
        if (cleanName == cleanDialogueName)
        {
            print("Found");
            text = ta.text;
            break;
        }
     }
