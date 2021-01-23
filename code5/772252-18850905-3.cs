    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SendInput
    {
       public class MouseInput
       {
          public static void LeftClick()
          {
             DoMouse( NativeMethods.MOUSEEVENTF.LEFTDOWN, new System.Drawing.Point( 0, 0 ) );
             DoMouse( NativeMethods.MOUSEEVENTF.LEFTUP, new System.Drawing.Point( 0, 0 ) );
          }
    
          public static void LeftClick( int x, int y )
          {
             DoMouse( NativeMethods.MOUSEEVENTF.MOVE | NativeMethods.MOUSEEVENTF.ABSOLUTE, new System.Drawing.Point( x, y ) );
             DoMouse( NativeMethods.MOUSEEVENTF.LEFTDOWN, new System.Drawing.Point( x, y ) );
             DoMouse( NativeMethods.MOUSEEVENTF.LEFTUP, new System.Drawing.Point( x, y ) );
          }
    
          public static void ClickBoundingRectangleByPercentage( int xPercentage, int yPercentage, System.Drawing.Rectangle bounds )
          {
             double additional = 0.0;
             if ( xPercentage == 99 )
                additional = 0.5;
             int xPixel = Convert.ToInt32( bounds.Left + bounds.Width * ( xPercentage + additional ) / 100 );
             int yPixel = Convert.ToInt32( bounds.Top + bounds.Height * ( yPercentage ) / 100 );
             LeftClick( xPixel, yPixel );
          }
    
          public static void RightClick()
          {
             DoMouse( NativeMethods.MOUSEEVENTF.RIGHTDOWN, new System.Drawing.Point( 0, 0 ) );
             DoMouse( NativeMethods.MOUSEEVENTF.RIGHTUP, new System.Drawing.Point( 0, 0 ) );
          }
    
          public static void RightClick( int x, int y )
          {
             DoMouse( NativeMethods.MOUSEEVENTF.MOVE | NativeMethods.MOUSEEVENTF.ABSOLUTE, new System.Drawing.Point( x, y ) );
             DoMouse( NativeMethods.MOUSEEVENTF.RIGHTDOWN, new System.Drawing.Point( x, y ) );
             DoMouse( NativeMethods.MOUSEEVENTF.RIGHTUP, new System.Drawing.Point( x, y ) );
          }
    
          public static void MoveMouse( Point p )
          {
             MoveMouse( p.X, p.Y );
          }
    
          public static void MoveMouse( System.Windows.Point p )
          {
             MoveMouse( Convert.ToInt32( p.X ), Convert.ToInt32( p.Y ) );
          }
    
          public static void MoveMouse( int x, int y )
          {
             DoMouse( NativeMethods.MOUSEEVENTF.MOVE | NativeMethods.MOUSEEVENTF.ABSOLUTE, new System.Drawing.Point( x, y ) );
          }
    
          public static System.Drawing.Point GetMousePosition()
          {
             return Cursor.Position;
          }
    
          public static void ScrollWheel( int scrollSize )
          {
             DoMouse( NativeMethods.MOUSEEVENTF.WHEEL, new System.Drawing.Point( 0, 0 ), scrollSize );
          }
    
          private static void DoMouse( NativeMethods.MOUSEEVENTF flags, Point newPoint, int scrollSize = 0 )
          {
             NativeMethods.INPUT input = new NativeMethods.INPUT();
             NativeMethods.MOUSEINPUT mi = new NativeMethods.MOUSEINPUT();
             input.dwType = NativeMethods.InputType.Mouse;
             input.mi = mi;
             input.mi.dwExtraInfo = IntPtr.Zero;
             // mouse co-ords: top left is (0,0), bottom right is (65535, 65535)
             // convert screen co-ord to mouse co-ords...
             input.mi.dx = newPoint.X * 65535 / Screen.PrimaryScreen.Bounds.Width;
             input.mi.dy = newPoint.Y * 65535 / Screen.PrimaryScreen.Bounds.Height;
             input.mi.time = 0;
             input.mi.mouseData = scrollSize * 120;
             // can be used for WHEEL event see msdn
             input.mi.dwFlags = flags;
             int cbSize = Marshal.SizeOf( typeof ( NativeMethods.INPUT ) );
             int result = NativeMethods.SendInput( 1, ref input, cbSize );
             if ( result == 0 )
                Debug.WriteLine( Marshal.GetLastWin32Error() );
          }
       }
    }
