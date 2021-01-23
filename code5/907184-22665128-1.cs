      [DllImport("user32.dll")]
      public static extern int ToUnicode(
          uint wVirtKey,
          uint wScanCode,
          byte[] lpKeyState,
          [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 4)] 
            StringBuilder pwszBuff,
          int cchBuff,
          uint wFlags);
      
      static string GetCharsFromKeys(Keys keys, bool shift, bool altGr)
      {
         var buf = new StringBuilder(256);
         var keyboardState = new byte[256];
         if (shift)
            keyboardState[(int)Keys.ShiftKey] = 0xff;
         if (altGr)
         {
            keyboardState[(int)Keys.ControlKey] = 0xff;
            keyboardState[(int)Keys.Menu] = 0xff;
         }
         ToUnicode((uint)keys, 0, keyboardState, buf, 256, 0);
         return buf.ToString();
      }
