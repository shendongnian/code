    var w = Console.WindowWidth;
    var h = Console.WindowHeight;
    Console.SetBufferSize(w, h);
    // Draw all but bottom-right 2 characters of box here ...
    // HACK: Console.Write will automatically advance the cursor position at the end of each
    // line which will push the buffer upwards resulting in the loss of the first line
    var sourceReplacement = '═';
    Console.SetCursorPosition(w - 2, h - 1); // bottom-right minus 1
    Console.Write('╝');
    // Move from bottom-right minus 1 to bottom-right overwriting the source
    // with the replacement character
    Console.MoveBufferArea(w - 2, h - 1, 1, 1, w - 1, h - 1,
        sourceReplacement, Console.ForegroundColor, Console.BackgroundColor);
