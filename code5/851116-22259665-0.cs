    <Window x:Class="BindingTest.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525" x:Name="self" DataContext="{Binding ElementName=self}">
        <Grid>
            <Button Click="ButtonClick">
    			<Button.Style>
    				<Style TargetType="Button">
    					<Style.Triggers>
    						<DataTrigger Binding="{Binding EnableSkinnyMode}" Value="True">
    							<Setter Property="Content" Value="Disable Skinny Mode "></Setter>
    						</DataTrigger>
    						<DataTrigger Binding="{Binding EnableSkinnyMode}" Value="False">
    							<Setter Property="Content" Value="Enable Skinny Mode "></Setter>
    						</DataTrigger>
    					</Style.Triggers>
    				</Style>
    			</Button.Style>
            </Button>
        </Grid>
    </Window>
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows;
    
    namespace BindingTest
    {
        public partial class MainWindow : IDisposable, INotifyPropertyChanged
        {
            public bool EnableSkinnyMode
            {
                get { return enableSkinnyMode; }
                set
                {
                    if (value == enableSkinnyMode) return;
                    enableSkinnyMode = value;
                    OnPropertyChanged("EnableSkinnyMode");
                }
            }
    
            private bool enableSkinnyMode;
            public MainWindow()
            {
                InitializeComponent();
                this.SourceInitialized += win_SourceInitialized;
            }
    
            private void ButtonClick(object sender, RoutedEventArgs e)
            {
                EnableSkinnyMode = EnableSkinnyMode == false;
            }
    
            private void win_SourceInitialized(object sender, EventArgs e)
            {
                System.IntPtr handle = (new System.Windows.Interop.WindowInteropHelper(this)).Handle;
                System.Windows.Interop.HwndSource.FromHwnd(handle).AddHook(WindowProc);
            }
    
            private System.IntPtr WindowProc(System.IntPtr hwnd, int msg, System.IntPtr wParam, System.IntPtr lParam, ref bool handled)
            {
                switch (msg)
                {
                    case 0x0024:/* WM_GETMINMAXINFO */
                        if (EnableSkinnyMode)
                        {
                            WindowInteropHelper.WmGetMinMaxInfo(this, hwnd, lParam);
                            handled = true;
                        }
                        break;
                }
    
                return (System.IntPtr)0;
            }
    
            public void Dispose()
            {
                this.SourceInitialized -= win_SourceInitialized;
                System.IntPtr handle = (new System.Windows.Interop.WindowInteropHelper(this)).Handle;
                System.Windows.Interop.HwndSource.FromHwnd(handle).RemoveHook(WindowProc);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class WindowInteropHelper
        {
            [DllImport("user32")]
            internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);
            [DllImport("User32")]
            internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
    
            public static void WmGetMinMaxInfo(Window window, System.IntPtr hwnd, System.IntPtr lParam)
            {
    
                MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
    
                // Adjust the maximized size and position to fit the work area of the correct monitor
                int MONITOR_DEFAULTTONEAREST = 0x00000002;
                System.IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
    
                if (monitor != System.IntPtr.Zero)
                {
    
                    MONITORINFO monitorInfo = new MONITORINFO();
                    GetMonitorInfo(monitor, monitorInfo);
                    RECT rcWorkArea = monitorInfo.rcWork;
                    RECT rcMonitorArea = monitorInfo.rcMonitor;
                    mmi.ptMaxPosition.x = (int)window.Left;
                    //mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                    mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                    mmi.ptMaxSize.x = (int)window.Width;
                    //mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                    mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
                    mmi.ptMinTrackSize.x = (int)window.MinWidth;
                    mmi.ptMinTrackSize.y = (int)window.MinHeight;
                }
    
                Marshal.StructureToPtr(mmi, lParam, true);
            }
    
            #region InteropStructs
            [StructLayout(LayoutKind.Sequential)]
            public struct MINMAXINFO
            {
                public POINT ptReserved;
                public POINT ptMaxSize;
                public POINT ptMaxPosition;
                public POINT ptMinTrackSize;
                public POINT ptMaxTrackSize;
            };
    
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                /// <summary>
                /// x coordinate of point.
                /// </summary>
                public int x;
                /// <summary>
                /// y coordinate of point.
                /// </summary>
                public int y;
    
                /// <summary>
                /// Construct a point of coordinates (x,y).
                /// </summary>
                public POINT(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public class MONITORINFO
            {
                /// <summary>
                /// </summary>            
                public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
    
                /// <summary>
                /// </summary>            
                public RECT rcMonitor = new RECT();
    
                /// <summary>
                /// </summary>            
                public RECT rcWork = new RECT();
    
                /// <summary>
                /// </summary>            
                public int dwFlags = 0;
            }
    
            [StructLayout(LayoutKind.Sequential, Pack = 0)]
            public struct RECT
            {
                /// <summary> Win32 </summary>
                public int left;
                /// <summary> Win32 </summary>
                public int top;
                /// <summary> Win32 </summary>
                public int right;
                /// <summary> Win32 </summary>
                public int bottom;
    
                /// <summary> Win32 </summary>
                public static readonly RECT Empty = new RECT();
    
                /// <summary> Win32 </summary>
                public int Width
                {
                    get { return Math.Abs(right - left); }  // Abs needed for BIDI OS
                }
                /// <summary> Win32 </summary>
                public int Height
                {
                    get { return bottom - top; }
                }
    
                /// <summary> Win32 </summary>
                public RECT(int left, int top, int right, int bottom)
                {
                    this.left = left;
                    this.top = top;
                    this.right = right;
                    this.bottom = bottom;
                }
    
    
                /// <summary> Win32 </summary>
                public RECT(RECT rcSrc)
                {
                    this.left = rcSrc.left;
                    this.top = rcSrc.top;
                    this.right = rcSrc.right;
                    this.bottom = rcSrc.bottom;
                }
    
                /// <summary> Win32 </summary>
                public bool IsEmpty
                {
                    get
                    {
                        // BUGBUG : On Bidi OS (hebrew arabic) left > right
                        return left >= right || top >= bottom;
                    }
                }
                /// <summary> Return a user friendly representation of this struct </summary>
                public override string ToString()
                {
                    if (this == RECT.Empty) { return "RECT {Empty}"; }
                    return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
                }
    
                /// <summary> Determine if 2 RECT are equal (deep compare) </summary>
                public override bool Equals(object obj)
                {
                    if (!(obj is Rect)) { return false; }
                    return (this == (RECT)obj);
                }
    
                /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
                public override int GetHashCode()
                {
                    return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
                }
    
    
                /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
                public static bool operator ==(RECT rect1, RECT rect2)
                {
                    return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom);
                }
    
                /// <summary> Determine if 2 RECT are different(deep compare)</summary>
                public static bool operator !=(RECT rect1, RECT rect2)
                {
                    return !(rect1 == rect2);
                }
            }
    
            #endregion
        }
    }
