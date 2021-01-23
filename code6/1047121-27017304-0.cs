        ...
        public class ScreensHandler
        {
            #region Attributes
            /// <summary>
            /// All information about all screen on a single system
            /// </summary        
            private ScreensInformations _screensInformation;
            /// <summary>
            /// Property all information about all screen on a single system
            /// </summary>        
            public ScreensInformations ScreensInformation
            {
                get
                {
                    if (this._screensInformation == null)
                    {
                        this._screensInformation = new ScreensInformations();
                    }
                    return this._screensInformation;
                }
            }
            
            /// <summary>
            /// Store the log when we call the method this.place_onscreen
            /// </summary>
            public string Log_place_onscreen { get; set; }
            #endregion
    
            #region Constructor
            public ScreensHandler()
            {
    
            }
            #endregion
    
            #region Place window on screen
            /// <summary>
            /// Place the window WindowHandle on the screen number index_screen
            /// </summary>
            /// <param name="WindowHandle">The window handle to place</param>
            /// <param name="index_screen"></param>
            /// <returns></returns>
            public bool place_onscreen(IntPtr WindowHandle, int index_screen)
            {
                bool isSuccess = false;
                if (index_screen < this.ScreensInformation.NumberScreen)
                {
                    if(this.ScreensInformation.Screens[index_screen] != null) 
                    {
                        Screen current_screen = this.ScreensInformation.Screens[index_screen];
                        Rectangle current_screen_WorkingArea = current_screen.WorkingArea;
                        
                        isSuccess = SetWindowPos(
                            WindowHandle,
                            HWND_TOP, // HWND_TOP = Places the window at the top of the Z order.
                            current_screen_WorkingArea.Left,
                            current_screen_WorkingArea.Top,
                            current_screen_WorkingArea.Width,
                            current_screen_WorkingArea.Height
                            ,0);
                        // SWP_NOSIZE | SWP_NOZORDER | SWP_NOACTIVATE
    
                        this.Log_place_onscreen =
                              "   ---{SUCESS}-----------------------------------------\n"
                            + "   | Place WindowHandle(#" + WindowHandle + ") on screen(#" + index_screen + ") \n" 
                            + "   | Device name : " + current_screen.DeviceName.ToString() + "\n"
                            + "   | Working area : " + current_screen.WorkingArea.ToString() + "\n"
                            + "   | Primary ? : " + current_screen.Primary.ToString() + "\n"
                            + "   ----------------------------------------------------\n";
                    } 
                }
                else 
                {
                    this.Log_place_onscreen =
                          "   ---{FAILED}-----------------------------------------\n"
                        + "   | The screen with index (#" + index_screen + ") doesn't exist \n"
                        + "   ----------------------------------------------------\n";
                }
                return isSuccess;
            }
    
            /// <summary>
            /// Use to go in full screen mode
            /// </summary>
            /// <param name="hWnd"></param>
            public void chrome_on_fullscreen(IntPtr hWnd)
            {
                SetForegroundWindow(hWnd);
                SendKeys.SendWait("{F11}");
            }
    
            #region Methods DllImport (user32.dll)
            /// <summary>
            /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
            /// </summary>
            /// <param name="hwnd"></param>
            /// <param name="hWndInsertAfter"></param>
            /// <param name="X"></param>
            /// <param name="Y"></param>
            /// <param name="cx"></param>
            /// <param name="cy"></param>
            /// <param name="wFlagslong"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            static extern bool SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int wFlagslong);
            const short SWP_NOSIZE = 0x0001;
            const short SWP_NOMOVE = 0x0002;
            const int SWP_NOZORDER = 0x0004;
            const int SWP_SHOWWINDOW = 0x0040;
            const int SWP_NOACTIVATE = 0x0010;
            const int HWND_TOP = 0;
    
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool SetForegroundWindow(IntPtr hWnd);
            #endregion
    
            #endregion
        }
    
