    var str = @"<p>something here<H3>Title</H3></p>";
    
    // Add and remove "<" chars on the stack. When we don't have any "<"
    // chars on the stack, it means we're in the contents sections of the tag.
    var stack = new Stack<string>();
    // Avoid peeking an empty stack.
    stack.Push("base");
    
    // This will be your resulting string and number of chars.
    var result = "";
    var resultLimit = 5;
    foreach (var ch in str)
    {
        // Limit reached.
        if (result.Count() == resultLimit)
            break;
    
        // Entering a tag.
        if (ch == '<')
            { stack.Push("start"); continue; }
        // Leaving a tag.
        if (ch == '>')
            { stack.Pop(); continue; }
    
        // We're not in a tag at the moment, so take this char.
        if (stack.Peek() != "start")
            result += ch;
    }
