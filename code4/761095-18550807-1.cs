    public static void WriteAt(int left, int top, string s){
       int currentLeft = Console.CursorLeft;
       int currentTop = Console.CursorTop;
       Console.CursorVisible = false;//Hide cursor
       Console.SetCursorPosition(left, top);
       Console.Write(s);
       Console.SetCursorPosition(currentLeft, currentTop);
       Console.CursorVisible = true;//Show cursor back
    }
    //Use it
    WriteAt(30, 20, k);
    WriteAt(15, 6, l);
