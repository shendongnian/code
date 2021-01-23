    static void Main(string[] args)
    {
        // ... other code and stuff
        int windowWidth;
        if (!ConsoleEx.GetConsoleWindowWidth(out windowWidth))
            windowWidth = Int32.MaxValue; // if no console, no limits
        // ... other code and stuff
    }
     
    internal static class ConsoleEx
    {
        /// <summary>
        /// Contains information about a console screen buffer.
        /// </summary>
        private struct ConsoleScreenBufferInfo
        {
            /// <summary> A CoOrd structure that contains the size of the console screen buffer, in character columns and rows. </summary>
            internal CoOrd dwSize;
            /// <summary> A CoOrd structure that contains the column and row coordinates of the cursor in the console screen buffer. </summary>
            internal CoOrd dwCursorPosition;
            /// <summary> The attributes of the characters written to a screen buffer by the WriteFile and WriteConsole functions, or echoed to a screen buffer by the ReadFile and ReadConsole functions. </summary>
            internal Int16 wAttributes;
            /// <summary> A SmallRect structure that contains the console screen buffer coordinates of the upper-left and lower-right corners of the display window. </summary>
            internal SmallRect srWindow;
            /// <summary> A CoOrd structure that contains the maximum size of the console window, in character columns and rows, given the current screen buffer size and font and the screen size. </summary>
            internal CoOrd dwMaximumWindowSize;
        }
        /// <summary>
        /// Defines the coordinates of a character cell in a console screen buffer. 
        /// The origin of the coordinate system (0,0) is at the top, left cell of the buffer.
        /// </summary>
        private struct CoOrd
        {
            /// <summary> The horizontal coordinate or column value. </summary>
            internal Int16 X;
            /// <summary> The vertical coordinate or row value. </summary>
            internal Int16 Y;
        }
        /// <summary>
        /// Defines file type values for use when retrieving the type of a specified file.
        /// </summary>
        private enum FileType
        {
            /// <summary> Either the type of the specified file is unknown, or the function failed. </summary>
            Unknown,
            /// <summary> The specified file is a disk file. </summary>
            Disk,
            /// <summary> The specified file is a character file, typically an LPT device or a console. </summary>
            Char,
            /// <summary> The specified file is a socket, a named pipe, or an anonymous pipe. </summary>
            Pipe
        };
        /// <summary>
        /// Gets a value that indicates whether the error output stream has been redirected from the standard error stream.
        /// </summary>
        internal static Boolean IsErrorRedirected
        {
            get { return FileType.Char != GetFileType(GetStdHandle(StdHandle.StdErr)); }
        }
        /// <summary>
        /// Gets a value that indicates whether input has been redirected from the standard input stream.
        /// </summary>
        internal static Boolean IsInputRedirected
        {
            get { return FileType.Char != GetFileType(GetStdHandle(StdHandle.StdIn)); }
        }
        /// <summary>
        /// Gets a value that indicates whether output has been redirected from the standard output stream.
        /// </summary>
        internal static Boolean IsOutputRedirected
        {
            get { return FileType.Char != GetFileType(GetStdHandle(StdHandle.StdOut)); }
        }
        /// <summary>
        /// Gets the column position of the cursor within the buffer area.
        /// </summary>
        /// <param name="returnLeftIfNone">
        /// In the event that there is no console, the value passed here will be the return value
        /// </param>
        /// <returns>
        /// The current position, in columns, of the cursor
        /// </returns>
        internal static Int32 GetConsoleCursorLeft(Int32 returnLeftIfNone = 0)
        {
            if (!IsOutputRedirected) // if the output is not being redirected
                return Console.CursorLeft; // return the current cursor [left] position
            else
            { // try and get the Console Buffer details
                ConsoleScreenBufferInfo csbi;
                if (GetConsoleScreenBufferInfo(GetStdHandle(StdHandle.StdOut), out csbi)) // if the console buffer exists
                    return csbi.dwCursorPosition.X; // return the cursor [left] position
            }
            return returnLeftIfNone; // no console; return the desired position in this event
        }
        /// <summary>
        /// Gets the console screen buffer window height.
        /// </summary>
        /// <param name="windowHeight">
        /// A System.Int32 property that will receive the console screen buffer height
        /// </param>
        /// <returns>
        /// Returns a System.Boolean value of true if a console screen exists and the height retrieved; else false
        /// </returns>
        internal static Boolean GetConsoleWindowHeight(out Int32 windowHeight)
        {
            int discardWidth;
            return GetConsoleWindowSize(out windowHeight, out discardWidth);
        }
        /// <summary>
        /// Gets the console screen buffer window size.
        /// </summary>
        /// <param name="windowHeight">
        /// A System.Int32 property that will receive the console screen buffer height
        /// </param>
        /// <param name="windowWidth">
        /// A System.Int32 property that will receive the console screen buffer width
        /// </param>
        /// <returns>
        /// Returns a System.Boolean value of true if a console screen exists and the information retrieved; else false
        /// </returns>
        internal static Boolean GetConsoleWindowSize(out Int32 windowHeight, out Int32 windowWidth)
        {
            windowHeight = 0;
            windowWidth = 0;
            if (!IsOutputRedirected)
            { // if the output is not being redirected
                windowHeight = Console.WindowHeight; // out the current console window height
                windowWidth = Console.WindowWidth; // out the current console window width
                return true;
            }
            else
            { // try and get the Console Buffer details
                ConsoleScreenBufferInfo csbi;
                if (GetConsoleScreenBufferInfo(GetStdHandle(StdHandle.StdOut), out csbi))
                { // if the console buffer exists
                    windowHeight = csbi.dwSize.Y; // out the current console window height
                    windowWidth = csbi.dwSize.X; // out the current console window width
                    return true;
                }
            }
            return false; // no console
        }
        /// <summary>
        /// Gets the console screen buffer window height.
        /// </summary>
        /// <param name="windowWidth">
        /// A System.Int32 property that will receive the console screen buffer width
        /// </param>
        /// <returns>
        /// Returns a System.Boolean value of true if a console screen exists and the width retrieved; else false
        /// </returns>
        internal static Boolean GetConsoleWindowWidth(out Int32 windowWidth)
        {
            int discardHeight;
            return GetConsoleWindowSize(out discardHeight, out windowWidth);
        }
        /// <summary>
        /// Retrieves information about the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer
        /// </param>
        /// <param name="lpConsoleScreenBufferInfo">
        /// A pointer to a ConsoleScreenBufferInfo structure that receives the console screen buffer information
        /// </param>
        /// <returns>
        /// If the information retrieval succeeds, the return value is nonzero; else the return value is zero
        /// </returns>
        [DllImport("kernel32.dll")]
        private static extern Boolean GetConsoleScreenBufferInfo(
            IntPtr hConsoleOutput,
            out ConsoleScreenBufferInfo lpConsoleScreenBufferInfo);
        /// <summary>
        /// Retrieves the file type of the specified file.
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file
        /// </param>
        /// <returns>
        /// Returns one of the FileType enum values
        /// </returns>
        [DllImport("kernel32.dll")]
        private static extern FileType GetFileType(IntPtr hFile);
        /// <summary>
        /// Retrieves a handle to the specified standard device (standard input, standard output, or standard error).
        /// </summary>
        /// <param name="nStdHandle">
        /// The standard device
        /// </param>
        /// <returns>
        /// Returns a value that is a handle to the specified device, or a redirected handle
        /// </returns>
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(StdHandle nStdHandle);
        /// <summary>
        /// Defines the coordinates of the upper left and lower right corners of a rectangle.
        /// </summary>
        private struct SmallRect
        {
            /// <summary> The x-coordinate of the upper left corner of the rectangle. </summary>
            internal Int16 Left;
            /// <summary> The y-coordinate of the upper left corner of the rectangle. </summary>
            internal Int16 Top;
            /// <summary> The x-coordinate of the lower right corner of the rectangle. </summary>
            internal Int16 Right;
            /// <summary> The y-coordinate of the lower right corner of the rectangle. </summary>
            internal Int16 Bottom;
        }
        /// <summary>
        /// Defines the handle type of a standard device.
        /// </summary>
        private enum StdHandle
        {
            /// <summary> The standard input device. Initially, this is the console input buffer, CONIN$. </summary>
            StdIn = -10,
            /// <summary> The standard output device. Initially, this is the active console screen buffer, CONOUT$. </summary>
            StdOut = -11,
            /// <summary> The standard error device. Initially, this is the active console screen buffer, CONOUT$. </summary>
            StdErr = -12
        };
        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write
        /// </param>
        /// <param name="valueLength">
        /// The length of the last line written from value
        /// </param>
        internal static void Write(String value, out Int32 valueLength)
        {
            string[] valueArray = value.Split(new char[] { '\r', '\n' }); // split the value by either carriage returns or a line feeds
            valueLength = valueArray[valueArray.Count() - 1].Length; // out the length of the last line
            Console.Write(value); // write the value to the output stream
        }
    }
