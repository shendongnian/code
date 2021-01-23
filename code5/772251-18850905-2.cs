    using System;
    using System.Runtime.InteropServices;
    
    public class NativeMethods
    {
       [DllImport( "user32.dll", SetLastError = true )]
       internal static extern Int32 SendInput( Int32 cInputs, ref INPUT pInputs, Int32 cbSize );
    
       [StructLayout( LayoutKind.Explicit, Pack = 1, Size = 28 )]
       internal struct INPUT
       {
          [FieldOffset( 0 )] public InputType dwType;
          [FieldOffset( 4 )] public MOUSEINPUT mi;
          [FieldOffset( 4 )] public KEYBDINPUT ki;
          [FieldOffset( 4 )] public HARDWAREINPUT hi;
       }
    
       [StructLayout( LayoutKind.Sequential, Pack = 1 )]
       internal struct MOUSEINPUT
       {
          public Int32 dx;
          public Int32 dy;
          public Int32 mouseData;
          public MOUSEEVENTF dwFlags;
          public Int32 time;
          public IntPtr dwExtraInfo;
       }
    
       [StructLayout( LayoutKind.Sequential, Pack = 1 )]
       internal struct KEYBDINPUT
       {
          public Int16 wVk;
          public Int16 wScan;
          public KEYEVENTF dwFlags;
          public Int32 time;
          public IntPtr dwExtraInfo;
       }
    
       [StructLayout( LayoutKind.Sequential, Pack = 1 )]
       internal struct HARDWAREINPUT
       {
          public Int32 uMsg;
          public Int16 wParamL;
          public Int16 wParamH;
       }
    
       internal enum InputType : int
       {
          Mouse = 0,
          Keyboard = 1,
          Hardware = 2
       }
    
       [Flags()]
       internal enum MOUSEEVENTF : int
       {
          MOVE = 0x1,
          LEFTDOWN = 0x2,
          LEFTUP = 0x4,
          RIGHTDOWN = 0x8,
          RIGHTUP = 0x10,
          MIDDLEDOWN = 0x20,
          MIDDLEUP = 0x40,
          XDOWN = 0x80,
          XUP = 0x100,
          VIRTUALDESK = 0x400,
          WHEEL = 0x800,
          ABSOLUTE = 0x8000
       }
    
       [Flags()]
       public enum KEYEVENTF : int
       {
          EXTENDEDKEY = 1,
          KEYUP = 2,
          UNICODE = 4,
          SCANCODE = 8
       }
    
       /// <summary>The MapVirtualKey function translates (maps) a virtual-key code into a scan
       /// code or character value, or translates a scan code into a virtual-key code
       /// </summary>
       /// <param name="uCode">[in] Specifies the virtual-key code or scan code for a key.
       /// How this value is interpreted depends on the value of the uMapType parameter</param>
       /// <param name="uMapType">[in] Specifies the translation to perform. The value of this
       /// parameter depends on the value of the uCode parameter.</param>
       /// <returns>Either a scan code, a virtual-key code, or a character value, depending on
       /// the value of uCode and uMapType. If there is no translation, the return value is zero</returns>
       /// <remarks></remarks>
       [DllImport( "User32.dll", SetLastError = false, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto )]
       public static extern UInt32 MapVirtualKey( UInt32 uCode, MapVirtualKeyMapTypes uMapType );
    
    
       /// <summary>The set of valid MapTypes used in MapVirtualKey
       /// </summary>
       /// <remarks></remarks>
       public enum MapVirtualKeyMapTypes : uint
       {
          /// <summary>uCode is a virtual-key code and is translated into a scan code.
          /// If it is a virtual-key code that does not distinguish between left- and
          /// right-hand keys, the left-hand scan code is returned.
          /// If there is no translation, the function returns 0.
          /// </summary>
          /// <remarks></remarks>
          MAPVK_VK_TO_VSC = 0x0,
    
          /// <summary>uCode is a scan code and is translated into a virtual-key code that
          /// does not distinguish between left- and right-hand keys. If there is no
          /// translation, the function returns 0.
          /// </summary>
          /// <remarks></remarks>
          MAPVK_VSC_TO_VK = 0x1,
    
          /// <summary>uCode is a virtual-key code and is translated into an unshifted
          /// character value in the low-order word of the return value. Dead keys (diacritics)
          /// are indicated by setting the top bit of the return value. If there is no
          /// translation, the function returns 0.
          /// </summary>
          /// <remarks></remarks>
          MAPVK_VK_TO_CHAR = 0x2,
    
          /// <summary>Windows NT/2000/XP: uCode is a scan code and is translated into a
          /// virtual-key code that distinguishes between left- and right-hand keys. If
          /// there is no translation, the function returns 0.
          /// </summary>
          /// <remarks></remarks>
          MAPVK_VSC_TO_VK_EX = 0x3,
    
          /// <summary>Not currently documented
          /// </summary>
          /// <remarks></remarks>
          MAPVK_VK_TO_VSC_EX = 0x4
       }
