    int GetCharCode(int UpLine, int DownLine, int LeftLine, int RightLine)
    {
        for(int i = 0; i < BoxDrawingCharList.Length; ++i){
            BoxDrawingChar ch = BoxDrawingCharList[i];
            if (ch.UpLine == UpLine && ch.DownLine == DownLine && ...)
                return i + 0x2500;
        }
        return 0;
    }
