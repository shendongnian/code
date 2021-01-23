    namespace DropShadowedWindow
    {
        public partial class DropShadowedWindowStyle
        {
            #region Helper Functions
                /// <summary>
                /// Return WinApi window handler from WPF window
                /// </summary>
                /// <param name="w"></param>
                /// <returns></returns>
                protected static IntPtr p_GetHW(Window w)
                {
                    var helper = new WindowInteropHelper(w);
                    return helper.Handle;
                }
                /// <summary>
                /// Get templated parent window, if it exists
                /// </summary>
                /// <param name="sender"></param>
                protected Window p_GetTemplatedWindow(object sender)
                {
                    var element = sender as FrameworkElement;
                    if (element != null)
                    {
                        var w = element.TemplatedParent as Window;
                        if (w != null) return w;
                    }
                    return null;
                }
            #endregion Helper Functions
            
            #region Window Event Hanlders
                protected enum SizingAction
                {
                    North = 3,
                    South = 6,
                    East = 2,
                    West = 1,
                    NorthEast = 5,
                    NorthWest = 4,
                    SouthEast = 8,
                    SouthWest = 7
                }
                protected void p_OnSizeS(object sender, MouseButtonEventArgs e) { p_OnSize(sender, SizingAction.South); }
                protected void p_OnSizeN(object sender, MouseButtonEventArgs e) { p_OnSize(sender, SizingAction.North); }
                protected void p_OnSizeE(object sender, MouseButtonEventArgs e) { p_OnSize(sender, SizingAction.East); }
                protected void p_OnSizeW(object sender, MouseButtonEventArgs e) { p_OnSize(sender, SizingAction.West); }
                protected void p_OnSizeNW(object sender, MouseButtonEventArgs e) { p_OnSize(sender, SizingAction.NorthWest); }
                protected void p_OnSizeNE(object sender, MouseButtonEventArgs e) { p_OnSize(sender, SizingAction.NorthEast); }
                protected void p_OnSizeSE(object sender, MouseButtonEventArgs e) { p_OnSize(sender, SizingAction.SouthEast); }
                protected void p_OnSizeSW(object sender, MouseButtonEventArgs e) { p_OnSize(sender, SizingAction.SouthWest); }
                /// <summary>
                /// Switch to resize mode by dragging corners
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="action"></param>
                protected void p_OnSize(object sender, SizingAction action)
                {
                    if (Mouse.LeftButton == MouseButtonState.Pressed)
                    {
                        var w = p_GetTemplatedWindow(sender);
                        if (w != null && w.WindowState == WindowState.Normal) p_DragSize(p_GetHW(w), action);
                    }
                }
            
            #endregion Window Event Hanlders
            #region P/Invoke
                const int WmSyscommand = 0x112;
                const int ScSize = 0xF000;
                [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
                private static extern IntPtr p_SendMessage(IntPtr h_wnd, uint msg, IntPtr w_param, IntPtr l_param);
                /// <summary>
                /// Activate resize mode
                /// </summary>
                /// <param name="handle"></param>
                /// <param name="sizing_action"></param>
                private void p_DragSize(IntPtr handle, SizingAction sizing_action)
                {
                    p_SendMessage(handle, WmSyscommand, (IntPtr)(ScSize + sizing_action), IntPtr.Zero);
                    p_SendMessage(handle, 514, IntPtr.Zero, IntPtr.Zero);
                }
            #endregion
        }
    }
