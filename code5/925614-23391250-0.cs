        public static void PressKey(char ch, bool press)
        {
            byte vk = MemoryApi.VkKeyScan(ch);
            PressKey((MemoryApi.KeyCode)vk, press);
        }
    
        public static void PressKey(MemoryApi.KeyCode vk, bool press)
        {
            ushort scanCode = (ushort)MemoryApi.MapVirtualKey((ushort)vk, 0);
    
            //Console.WriteLine("SendInput:: VK: " + (ushort)vk + " (" + vk + ") <-> SC: " + (ushort)(scanCode & 0xff));
    
            if (press)
                KeyDown(scanCode);
            else
                KeyUp(scanCode);
        }
    
        public static void KeyDown(ushort scanCode)
        {
            //Console.WriteLine("Key Down (SC): " + (ushort)(scanCode & 0xff));
            MemoryApi.INPUT[] inputs = new MemoryApi.INPUT[1];
    
            inputs[0].type = MemoryApi.INPUT_KEYBOARD;
            inputs[0].ki.wScan = (ushort)(scanCode & 0xff);
            inputs[0].ki.dwFlags = MemoryApi.KEYEVENTF_SCANCODE;
            inputs[0].ki.time = 0;
            inputs[0].ki.dwExtraInfo = IntPtr.Zero;
    
            uint intReturn = MemoryApi.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
            if (intReturn != 1)
            {
                throw new Exception("Could not send key: " + scanCode);
            }
        }
    
        public static void KeyUp(ushort scanCode)
        {
            //Console.WriteLine("Key Up (SC): " + scanCode);
            MemoryApi.INPUT[] inputs = new MemoryApi.INPUT[1];
    
            inputs[0].type = MemoryApi.INPUT_KEYBOARD;
            inputs[0].ki.wScan = (ushort)(scanCode & 0xff);
            inputs[0].ki.dwFlags = MemoryApi.KEYEVENTF_SCANCODE | MemoryApi.KEYEVENTF_KEYUP;
            inputs[0].ki.time = 0;
            inputs[0].ki.dwExtraInfo = IntPtr.Zero;
    
            uint intReturn = MemoryApi.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
            if (intReturn != 1)
            {
                throw new Exception("Could not send key: " + scanCode);
            }
    }
