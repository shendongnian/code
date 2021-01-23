    public class FontResizeFactorProvider
        {
            private const int DpiSmallSize = 96;
            private const int DpiMediumSize = 120;
            private const int DpiLargeSize = 144;
    
            public float GetFontResizeFactor()
            {
                var graphics = Graphics.FromHwnd(IntPtr.Zero);
                IntPtr desktop = graphics.GetHdc();
    
                var displayDimensions = new List<int>
                    {
                        GetDeviceCaps(desktop, (int) DeviceCap.LOGPIXELSX),
                        GetDeviceCaps(desktop, (int) DeviceCap.LOGPIXELSY)
                    };
    
                var matchedDim = displayDimensions.First(dim => dim == DpiSmallSize || dim == DpiMediumSize || dim == DpiLargeSize);
    
                if (matchedDim == default(int))
                {
                    throw new ArgumentException("Dpi size not standard.");
                }
    
                var resizeFactor = (float) DpiSmallSize/matchedDim;
    
                return resizeFactor;
            }
    
            [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
            public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);
    
            public enum DeviceCap
            {
                /// <summary>
                /// Logical pixels inch in X
                /// </summary>
                LOGPIXELSX = 88,
                /// <summary>
                /// Logical pixels inch in Y
                /// </summary>
                LOGPIXELSY = 90
    
                // Other constants may be founded on pinvoke.net
            }
        }
