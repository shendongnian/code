        static void writeCol(string a, ConsoleColor b)
        {
            byte x = 0, y = 0;
            // parsing to make it  fly
            // fill the buffer with the string 
            for(int ci=0; ci<a.Length;ci++)
            {
                switch (a[ci])
                {
                    case '\n': // newline char, move to next line, aka y=y+1
                        y++;
                        x=0;
                        break;
                    case '\r': // do nothing
                        break;
                    case ' ': // a space, move the cursor to the right
                        x++;
                        break;
                    default:
                        // calculate where we should be in the buffer
                        int i = y * 80 + x;
                        // color
                        buf[i].Attributes= (short) b;
                        // put the current char from the string in the buffer
                        buf[i].Char.AsciiChar = (byte) a[ci];
                        x++;
                        break;
                }
            }
            // we handled our string, let's write the whole screen at once
            bool success = WriteConsoleOutput(h, buf,
                         new Coord() { X = 80, Y = 25 },
                         new Coord() { X = 0, Y = 0 },
                         ref rect);
        }
