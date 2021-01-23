    class HookingClass
    {
        private delegate IntPtr CBTProc(HCBT nCode, IntPtr wParam, IntPtr lParam);
        private readonly CBTProc _callbackDelegate;
        public HookingClass()
        {
             _callbackDelegate = CallbackFunction;
        }
        private IntPtr _hook;
        
        private void CreateHook()
        {
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                IntPtr hModule = GetModuleHandle(module.ModuleName);
            
                _hook = SetWindowsHookEx(HookType.WH_CBT, _callbackDelegate, hModule, 0);
                if(_hook == IntPtr.Zero)
                    throw new Win32Exception(); //The default constructor automatically calls Marshal.GetLastError()
            }
        
        }
        
        private void Unhook()
        {
            var success = UnhookWindowsHookEx(_hook);
            if(!success)
                throw new Win32Exception();
        }
    
         private IntPtr CallbackFunction(HCBT code, IntPtr wParam, IntPtr lParam)
         {
             if (code != HCBT.CreateWnd && code != HCBT.DestroyWnd) 
             {         
                 return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
             }
    
             //Do whatever with the created or destroyed window.
    
             return CallNextHookEx(IntPtr.Zero, (int)code, wParam, lParam);
         }
    }
