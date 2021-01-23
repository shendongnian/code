    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace ConsoleApplication1
    {
       class Program
       {
          private static long _i;
          private static readonly System.Timers.Timer Timer = new System.Timers.Timer( 1000 );
          [DllImport( "user32.dll" )]
          private static extern IntPtr GetForegroundWindow();
    
          [DllImport( "user32.dll" )]
          private static extern int GetWindowText( IntPtr hWnd, StringBuilder text, int count );
    
          [DllImport( "user32.dll" )]
          private static extern int GetWindowModuleFileName( IntPtr hWnd, StringBuilder text, int count );
    
          [DllImport( "user32.dll", SetLastError = true )]
          public static extern int GetWindowThreadProcessId( IntPtr hwnd, ref int lpdwProcessId );
    
          static void Main()
          {
    
    
             Timer.Elapsed += Timer_Elapsed;
             Timer.AutoReset = true;
             Timer.Start();
             while ( Timer.Enabled )
                Console.ReadLine();
          }
    
          static void Timer_Elapsed( object sender, System.Timers.ElapsedEventArgs e )
          {
             Console.WriteLine( "-|- - " + _i + " - -|-" );
             Console.WriteLine( "WindowHandle: " + GetForegroundWindow() );
    
             string name = GetProcessEXENameUsingWMI( GetProcess( GetForegroundWindow() ) );
    
             Console.WriteLine( "ModuleName: " + Path.GetFileName( name ) );
    
             Console.WriteLine( "-|- - | - -|-" );
             _i++;
    
          }
    
          private static string GetProcessEXENameUsingWMI( Process p )
          {
             ManagementObjectSearcher mos = new ManagementObjectSearcher( "SELECT ExecutablePath FROM Win32_Process WHERE ProcessId=" + p.Id.ToString() );
             ManagementObjectCollection moc = mos.Get();
    
             foreach ( ManagementObject mo in moc )
             {
                string executablePath = mo[ "ExecutablePath" ].ToString();
                return executablePath;
             }
    
             return "";
          }
    
          public static Process GetProcess( IntPtr hwnd )
          {
             int intID = 0;
             GetWindowThreadProcessId( hwnd, ref intID );
             return Process.GetProcessById( intID );
          }
    
       }
    }
