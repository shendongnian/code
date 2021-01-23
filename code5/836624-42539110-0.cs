    /*
    
      Purpose: Set a TrueType font in the Windows command window, in order that
               multinational characters have a fighting chance of being readable.
    
    
      Usage: This should only work on Windows Vista or Server 2008 and later.
             To check, use the 'ver' command and disallow the strings " 2000 ",
             " 2003 ", and " XP ".  Or allow only the strings " 6." and "10.".
             One way to do it is using the DOS commands:
             ver | findstr /r /c:"\[[^ ]*  *[16]" > "%TEMP%\nul"
             if errorlevel 1 goto skipfont
    
             If OK, use:
                askufont [/d] FONTNAME
             Here /d, if present, turns on debug mode.
    
             Return status: If the errorlevel is zero, supposedly *some* Truetype
                            font has been set.
    
             To see whether, say, font Consolas has really been set and not, say,
             font "Lucida Console", use:
                askufont Consolas
                if errorlevel 1 goto err
                askufont /d Consolas | find "Got font name: Consolas"
                if errorlevel 1 goto err
    
             askufont /?: displays help info on standard error.
             askufont /.: returns errorlevel 175.
             askufont /!: writes "askufont.cs by Leon van Dommelen v1" to standard
                          output (not standard error) and returns errorlevel 177.
                          Subsequent backward-compatible version numbers can be
                          appended to v1 (e.g. v12 for version 2).
    
      Copyright: Copyright 2017 Leon van Dommelen.  This software is made
                 available under the GNU Public License version 3.
                 There is no warrantee of any kind on this free software.
    
                 This originated from
                    https://msdn.microsoft.com/en-us/library/System.Console.aspx
                 but that did not work.
    
                 I got error corrections from "thirdwaffle" in the thread
                    http://stackoverflow.com/questions/20631634/
                    changing-font-in-a-console-window-in-c-sharp
                 In particular, the last argument of SetCurrentConsoleFont was
                 corrected to a pointer just like in GetCurrentConsoleFont.  And
                 the charset in CONSOLE_FONT_INFOEX was changed to Unicode.
    
                 After that, it still did not work.  Turned out to be bad values
                 for the newInfo buffer below. I got values that actually work
                 (for me) from
                    http://www.janthor.com/sketches/index.php?/archives/19-How-
                    to-change-the-font-of-the-Windows-console-with-Python.html
                 He lists:
                    TERMINAL = Font(9, 10, 18, 48, 400, "Terminal")
                    CONSOLAS = Font(9, 8, 18, 54, 400, "Consolas")
                    LUCIDA = Font(12, 11, 18, 54, 400, "Lucida Console")
                    LUCIDA14 = Font(12, 8, 14, 54, 400, "Lucida Console")
                 The key is that the font family *must* be 54, not just the
                 TT bit of it.
    
                 Finally, I rewrote it all to make it more usable and changeable.
    
      Make: C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe/unsafe askufont.cs
    
    */
    
    using System;
    using System.Runtime.InteropServices;
    
    public class SetTTFont
    {
    
        // Import GetStdHandle to get a handle on the terminal output.
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);
    
        // Import GetCurrentConsoleFontEx for current font info.
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool GetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFOEX lpConsoleCurrentFontEx);
    
        // Import SetCurrentConsoleFontEx to change the font.
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFOEX lpConsoleCurrentFontEx);
    
        // Define descriptive names for some constants.
        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int FONT_FAMILY = 54;
        private const int LF_FACESIZE = 32;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
    
        public static unsafe int Main( string[] args )
        {
            // whether we are in debug mode
            bool debug = false;
            // handle on standard output
            IntPtr hnd;
            // old and new console information structures
            CONSOLE_FONT_INFOEX oldInfo, newInfo, setInfo;
            // converted char[] string
            string str;
            // argument index
            int i;
    
            // process arguments
            for (i=0; i<args.Length; i++) {
                if (args[i].Length < 1) {
                    Console.Error.WriteLine("*** askufont: Nil argument {0}", i+1);
                    Console.Error.WriteLine("    Enter askufont /? for help.");
                    return 2;
                }
                if (args[i][0] != '/') {
                    break;
                }
                if (args[i].Length != 2 || args[i][0] != '/') {
                    Console.Error.WriteLine(
                                "*** askufont: Bad option {0}: {1}", i+1, args[i]);
                    Console.Error.WriteLine("    Enter askufont /? for help.");
                    return 2;
                }
                if (args[i][1] == 'd' || args[i][1] == 'D') {
                    debug = true;
                }
                else if (args[i][1] == '?') {
                    Console.Error.WriteLine(
    "              askufont is Copyright 2017 Leon van Dommelen.");
                    Console.Error.WriteLine(
    "  This software is made available under the GNU Public License version 3.");
                    Console.Error.WriteLine(
    "         There is no warrantee of any kind on this free software.");
                    Console.Error.WriteLine(
    "Usage: askufont [/d] FONTNAME");
                    Console.Error.WriteLine(
    "Tries to set a TrueType console font.");
                    Console.Error.WriteLine(
    "/d: Output debug information.");
                    Console.Error.WriteLine(
    "FONTNAME: a TrueType font name like \"Lucida Console\" or Consolas.");
                    Console.Error.WriteLine(
    "Works for Windows Vista and later only; in the output of the VER command,");
                    Console.Error.WriteLine(
    "disallow the strings \" 2000 \", \" 2003 \", and \" XP \" using FIND.");
                    Console.Error.WriteLine(
    "See the askufont.cs source for more details.");
                    Console.Error.WriteLine(
    "Version: Leon van Dommelen 1.");
                    return 2;
                }
                else if(args[i][1] == '.') {
                    return 175;
                }
                else if(args[i][1] == '!') {
                    Console.WriteLine("askufont.cs by Leon van Dommelen v1");
                    return 177;
                }
                else {
                    Console.Error.WriteLine(
                                "*** askufont: Bad option {0}: {1}", i+1, args[i]);
                    Console.Error.WriteLine("    Enter askufont /? for help.");
                    return 2;
                }
            }
    
            // Check the font argument.
            if (i > args.Length-1) {
                Console.Error.WriteLine("*** askufont: Missing font name.");
                Console.Error.WriteLine("    Enter askufont /? for help.");
                return 2;
            }
            if (i < args.Length-1) {
                Console.Error.WriteLine("*** askufont: Misplaced font name.");
                Console.Error.WriteLine("    Enter askufont /? for help.");
                return 2;
            }
            if (debug) Console.Error.WriteLine(
                                             "Requested Font: {0}", args[i]);
    
            // get a handle on standard output
            hnd = GetStdHandle(STD_OUTPUT_HANDLE);
            if (hnd == INVALID_HANDLE_VALUE) {
                Console.Error.WriteLine(
                       "*** askufont: Unable to get a handle on standard output!");
                return 2;
            }
    
            // First determine the current font information.
            oldInfo = new CONSOLE_FONT_INFOEX();
            oldInfo.cbSize = (uint) Marshal.SizeOf(oldInfo);
            if (!GetCurrentConsoleFontEx(hnd, false, ref oldInfo)) {
                Console.Error.WriteLine(
                          "*** askufont: Unable to get console font information!");
                return 2;
            }
            if (debug) {
                Console.Error.WriteLine(
                                   "Old font info block size: {0}", oldInfo.cbSize);
                Console.Error.WriteLine("Old font font number: {0}", oldInfo.nFont);
                Console.Error.WriteLine(
                                      "Old font width:  {0}", oldInfo.dwFontSize.X);
                Console.Error.WriteLine(
                                      "Old font height: {0}", oldInfo.dwFontSize.Y);
                Console.Error.WriteLine("Old font family: {0}", oldInfo.FontFamily);
                Console.Error.WriteLine("Old font weight: {0}", oldInfo.FontWeight);
                str = new string(oldInfo.FaceName);
                Console.Error.WriteLine("Old font name: {0}", str);
            }
    
            // Set generic data for the new font, taking some from the old font.
            newInfo = new CONSOLE_FONT_INFOEX();
            newInfo.cbSize = (uint) Marshal.SizeOf(newInfo);
            newInfo.nFont = 0;
            newInfo.FontFamily = FONT_FAMILY;
            IntPtr ptr = new IntPtr(newInfo.FaceName);
            Marshal.Copy(args[i].ToCharArray(), 0, ptr, args[i].Length);
            newInfo.dwFontSize=new COORD(oldInfo.dwFontSize.X,oldInfo.dwFontSize.Y);
            newInfo.FontWeight = oldInfo.FontWeight;
            if (debug) {
                Console.Error.WriteLine(
                                   "New font info block size: {0}", newInfo.cbSize);
                Console.Error.WriteLine("New font font number: {0}", newInfo.nFont);
                Console.Error.WriteLine(
                                      "New font width:  {0}", newInfo.dwFontSize.X);
                Console.Error.WriteLine(
                                      "New font height: {0}", newInfo.dwFontSize.Y);
                Console.Error.WriteLine("New font family: {0}", newInfo.FontFamily);
                Console.Error.WriteLine("New font weight: {0}", newInfo.FontWeight);
                str = new string(newInfo.FaceName);
                Console.Error.WriteLine("New font name: {0}", str);
            }
    
            // Try setting the new font.
            SetCurrentConsoleFontEx(hnd, false, ref newInfo);
            setInfo = new CONSOLE_FONT_INFOEX();
            setInfo.cbSize = (uint) Marshal.SizeOf(setInfo);
            if (!GetCurrentConsoleFontEx(hnd, false, ref setInfo)) {
                Console.Error.WriteLine(
                          "*** askufont: Unable to get the new font information!");
                return 2;
            }
            if (debug) {
                Console.Error.WriteLine(
                                   "Got font info block size: {0}", setInfo.cbSize);
                Console.Error.WriteLine("Got font font number: {0}", setInfo.nFont);
                Console.Error.WriteLine(
                                      "Got font width:  {0}", setInfo.dwFontSize.X);
                Console.Error.WriteLine(
                                      "Got font height: {0}", setInfo.dwFontSize.Y);
                Console.Error.WriteLine("Got font family: {0}", setInfo.FontFamily);
                Console.Error.WriteLine("Got font weight: {0}", setInfo.FontWeight);
                str = new string(setInfo.FaceName);
                Console.Error.WriteLine("Got font name: {0}", str);
            }
    
            // Check that at least we have a TT font now.
            if ((setInfo.FontFamily & TMPF_TRUETYPE) != TMPF_TRUETYPE) {
                Console.Error.WriteLine(
                                   "*** askufont: Error setting a TrueType font!");
                return 2;
            }
    
            // Done.
            return 0;
        }
    
        // Define the COORD structure.
        [StructLayout(LayoutKind.Sequential)]
        internal struct COORD
        {
            internal short X;
            internal short Y;
    
            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }
    
        // Define the CONSOLE_FONT_INFOEX structure.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CONSOLE_FONT_INFOEX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }
    }
