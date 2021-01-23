    public class Program : RichTextBox
    {
       
        /// <summary>
        /// Function to retrieve raw input data.
        /// </summary>
        /// <param name="hRawInput">Handle to the raw input.</param>
        /// <param name="uiCommand">Command to issue when retrieving data.</param>
        /// <param name="pData">Raw input data.</param>
        /// <param name="pcbSize">Number of bytes in the array.</param>
        /// <param name="cbSizeHeader">Size of the header.</param>
        /// <returns>0 if successful if pData is null, otherwise number of bytes if pData is not null.</returns>
     
        [DllImport("User32.dll")]
        extern static uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessages.RawInput)  // WindowMessages.RawInput = 0x00FF (WM_INPUT)
            {
                RAWINPUT input = new RAWINPUT();
                int outSize = 0;
                int size = Marshal.SizeOf(typeof(RAWINPUT));
                outSize = Win32API.GetRawInputData(m.LParam, RawInputCommand.Input, out input, ref size, Marshal.SizeOf(typeof(RAWINPUTHEADER)));
                if (outSize != -1)
                {
                    if (input.Header.Type == RawInputType.Joystick)
                    {
                              // Output X and Y coordinates of Joystick movements                  
                   }
            }
            base.WndProc(ref m);
        }
    }
}
