      public static void LeftClick()
      {
         DoMouse( NativeMethods.MOUSEEVENTF.LEFTDOWN, new Point( 0, 0 ) );
         System.Threading.Thread.Sleep( 200 );
         DoMouse( NativeMethods.MOUSEEVENTF.LEFTUP, new Point( 0, 0 ) );
      }
