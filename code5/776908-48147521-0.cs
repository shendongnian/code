    if (Utility.IsNumericType(column.ValueType) || IsDateColumn(columnName)) //render as left-to-right
        KeyboardUtility.KeyPressByHold(Keys.ControlKey, Keys.LShiftKey); //CTRL+LeftShift = Left-To-Right direction 
    else //render as right-to-left
        KeyboardUtility.KeyPressByHold(Keys.ControlKey, Keys.RShiftKey); //CTRL+RightShift = Right-To-Left direction 
     --------------------------
		public static void KeyPressByHold(Keys holdKey, Keys pressKey)
		{
            KeyDown(holdKey); // => keybd_event(key, flag);
			KeyPress(pressKey);
			KeyUp(holdKey);
		}
		/// <param name="bVirtualKey">Virtual Keycode of keys. E.g. VK_RETURN, VK_TAB, … You may use Keys enumeration in .Net for this.</param>
		/// <param name="bScanCode">Scan Code value of the keys (scan code is a hardware dependent code based on the model of the keyboard). E.g. 0xb8 for “Left Alt” key.</param>
		/// <param name="dwFlags">Flag that is set for key state. E.g. KEYEVENTF_KEYUP or KEYEVENTF_EXTENDEDKEY</param>
		/// <param name="dwExtraInfo">32-bit extra information about keystroke.</param>
		public static void keybd_event(Keys VirtualKey, KeyEventF dwFlags) // bool flagKeyUp, bool flagExtendedKey) //this version is more easy to call in .Net
		{
			uint ScanCode = MapVirtualKey((uint)VirtualKey, 0); // 0 = VirtualKey to ScanCode
			keybd_event((byte)VirtualKey, (byte)ScanCode, (uint)dwFlags, 0);
		}
