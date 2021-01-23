    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    using HQ.Util.General;
    using HQ.Util.Unmanaged;
    using HQ.Wpf.Util;
    using Microsoft.Win32;
    using SpreadsheetGear;
    
    namespace MonitorMe
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public enum HookType : int
    		{
    			WH_JOURNALRECORD = 0,
    			WH_JOURNALPLAYBACK = 1,
    			WH_KEYBOARD = 2,
    			WH_GETMESSAGE = 3,
    			WH_CALLWNDPROC = 4,
    			WH_CBT = 5,
    			WH_SYSMSGFILTER = 6,
    			WH_MOUSE = 7,
    			WH_HARDWARE = 8,
    			WH_DEBUG = 9,
    			WH_SHELL = 10,
    			WH_FOREGROUNDIDLE = 11,
    			WH_CALLWNDPROCRET = 12,
    			WH_KEYBOARD_LL = 13,
    			WH_MOUSE_LL = 14
    		}
    
    		delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
    
    		private HotKeyHandeler _hotKeyHandler = null;
    		private Timer _timerToMonitorScreenSaver = null;
    		// ************************************************************************
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
    			Monitor.Instance.Add(SessionSwitchReason.SessionLogon);
    
    			_timerToMonitorScreenSaver = new Timer(TimerCallbackMonitorScreenSaver, this, 3000, 3000);
    		}
    
    		private void TimerCallbackMonitorScreenSaver(object state)
    		{
    			int active = 1;
    			SystemParametersInfo(SPI_GETSCREENSAVERRUNNING, 0, ref active, 0);
    			if (active == 1)
    			{
    				Debug.Print("Timer detected Screen Saver activated on: " + DateTime.Now.ToString());
    			}
    		}
    
    		[DllImport("user32.dll", SetLastError = true)]
    		static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);
    
    		[DllImport("user32.dll")]
    		static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    
    		[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    		static extern IntPtr LoadLibrary(string lpFileName);
    
    		// Signatures for unmanaged calls
    		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    		private static extern bool SystemParametersInfo(
    		   int uAction, int uParam, ref int lpvParam,
    		   int flags);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    		private static extern bool SystemParametersInfo(
    		   int uAction, int uParam, ref bool lpvParam,
    		   int flags);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    		private static extern int PostMessage(IntPtr hWnd,
    		   int wMsg, int wParam, int lParam);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    		private static extern IntPtr OpenDesktop(
    		   string hDesktop, int Flags, bool Inherit,
    		   uint DesiredAccess);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    		private static extern bool CloseDesktop(
    		   IntPtr hDesktop);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    		private static extern bool EnumDesktopWindows(
    		   IntPtr hDesktop, EnumDesktopWindowsProc callback,
    		   IntPtr lParam);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    		private static extern bool IsWindowVisible(
    		   IntPtr hWnd);
    
    		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    		public static extern IntPtr GetForegroundWindow();
    
    		// Callbacks
    		private delegate bool EnumDesktopWindowsProc(
    		   IntPtr hDesktop, IntPtr lParam);
    
    		// Constants
    		private const int SPI_GETSCREENSAVERACTIVE = 16;
    		private const int SPI_SETSCREENSAVERACTIVE = 17;
    		private const int SPI_GETSCREENSAVERTIMEOUT = 14;
    		private const int SPI_SETSCREENSAVERTIMEOUT = 15;
    		private const int SPI_GETSCREENSAVERRUNNING = 114;
    		private const int SPIF_SENDWININICHANGE = 2;
    
    		private const uint DESKTOP_WRITEOBJECTS = 0x0080;
    		private const uint DESKTOP_READOBJECTS = 0x0001;
    		private const int WM_CLOSE = 16;
    
    
    		[DllImport("User32.dll")]
    		public static extern int SendMessage
    			(IntPtr hWnd,
    			uint Msg,
    			uint wParam,
    			uint lParam);
    
    		public enum SpecialHandles
    		{
    			HWND_DESKTOP = 0x0,
    			HWND_BROADCAST = 0xFFFF
    		}
    
    		// Registers a hot key with Windows.
    		[DllImport("user32.dll")]
    		private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
    		// Unregisters the hot key with Windows.
    		[DllImport("user32.dll")]
    		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
    
    		private IntPtr _hHook;
    
    		// ************************************************************************
    		void _hotKeyHandler_HotKeyPressed(object sender, HotKeyEventArgs e)
    		{
    			ActivateScreenSaver();
    		}
    
    		// ************************************************************************
    		private IntPtr MessageHookProc(int code, IntPtr wParam, IntPtr lParam)
    		{
    			if (code == WM_SYSCOMMAND)
    			{
    				Debug.Print("SysCommand : " + wParam);
    				if ((wParam.ToInt32() & 0xfff0) == SC_SCREENSAVE)
    				{
    					Debug.Print("MessageHookProc" + DateTime.Now.ToString());
    				}
    			}
    
    			return CallNextHookEx(_hHook, code, wParam, lParam);
    		}
    
    		// ************************************************************************
    		private const Int32 WM_SYSCOMMAND = 0x0112;
    		private const int SC_SCREENSAVE = 0xF140;
    		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    		{
    			if (msg == WM_SYSCOMMAND)
    			{
    				Debug.Print("SysCommand : " + wParam);
    				if ((wParam.ToInt32() & 0xfff0) == SC_SCREENSAVE)
    				{
    					// Works fine in almost all cases. I already did some code in the past which activate the screen saver
    					// but I never receive any WM_SYSCOMMAND for that code, I do not have source code for it anymore).
    					Debug.Print("WndProc" + DateTime.Now.ToString());
    				}
    			}
    
    			return IntPtr.Zero;
    		}
    
    		// ************************************************************************
    		void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
    		{
    			Monitor.Instance.Add(e.Reason);
    		}
    
    		// ************************************************************************
    		private void CmdExportToExcel_Click(object sender, RoutedEventArgs e)
    		{
    			ExportToExcel();
    		}
    
    		// ************************************************************************
    		private void ExportToExcel()
    		{
    			IWorkbook wb = Factory.GetWorkbook();
    			IWorksheet workSheet = wb.Worksheets[0];
    
    			int col = 1;
    			for (int dayIndex = -30; dayIndex <= 0; dayIndex++)
    			{
    				DateTime day = DateTime.Today + new TimeSpan(dayIndex, 0, 0, 0);
    				Debug.Print(day.ToString("yyyy-MM-dd"));
    
    				workSheet.Cells[0, col].Value = day.DayOfWeek.ToString();
    				workSheet.Cells[1, col].Value = day;
    
    				DayMonitor dayMonitor = Monitor.Instance.DayMonitors.FirstOrDefault(dm => dm.Day == day);
    				if (dayMonitor != null)
    				{
    
    					workSheet.Cells[2, col].Value = "Last - First";
    					workSheet.Cells[2, col + 1].Value = dayMonitor.TotalHours;
    
    					workSheet.Cells[3, col].Value = "Has estimated time (7h00 or 18h00)";
    					workSheet.Cells[3, col + 1].Value = dayMonitor.HasSomeEstimatedHours;
    
    					int row = 5;
    					foreach (var state in dayMonitor.SessionLockStateChanges)
    					{
    						workSheet.Cells[row, col].Value = state.SessionSwitchReason.ToString();
    						workSheet.Cells[row, col + 1].Value = state.DateTime;
    						row++;
    					}
    				}
    
    				workSheet.Cells[1, col].ColumnWidth = 18;
    				workSheet.Cells[1, col + 1].ColumnWidth = 18;
    
    				col += 2;
    			}
    
    
    			if (wb != null)
    			{
    				if (FileAssociation.IsFileAssociationExistsForExtensionWithDot(".xlsx"))
    				{
    					string path = TempFolderAutoClean.GetTempFileName("xlsx", "Export ");
    					wb.SaveAs(path, FileFormat.OpenXMLWorkbook);
    
    					Process p = new Process();
    					p.StartInfo.UseShellExecute = true;
    					p.StartInfo.FileName = path;
    					p.Start();
    				}
    				else
    				{
    					SaveFileDialog saveFileDialog = new SaveFileDialog();
    					saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
    					saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
    					saveFileDialog.DefaultExt = ".xlsx";
    
    					if (saveFileDialog.ShowDialog(Application.Current.MainWindow) == true)
    					{
    						string path = saveFileDialog.FileName;
    						wb.SaveAs(path, FileFormat.OpenXMLWorkbook);
    					}
    				}
    			}
    		}
    
    		// ************************************************************************
    		private void PrintOnExecuted(object sender, ExecutedRoutedEventArgs e)
    		{
    			ExportToExcel();
    		}
    
    		// ************************************************************************
    		private void ExitOnExecuted(object sender, ExecutedRoutedEventArgs e)
    		{
    			this.Close();
    		}
    
    		// ************************************************************************
    		private void PrintOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
    		{
    			e.CanExecute = true;
    			e.ContinueRouting = false;
    		}
    
    		// ************************************************************************
    		private void ExitOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
    		{
    			e.CanExecute = true;
    			e.ContinueRouting = false;
    		}
    
    		// ************************************************************************
    		private void CmdLaunchScreenSaver_Click(object sender, RoutedEventArgs e)
    		{
    			ActivateScreenSaver();
    		}
    
    		// ************************************************************************
    		private void ActivateScreenSaver()
    		{
    			// Next won't work in a secured Screen Saver by Account Policy (ex: by a domain policy)
    			//int nullVar = 0;
    			//SystemParametersInfo(SPI_SETSCREENSAVERACTIVE, 1, ref nullVar, SPIF_SENDWININICHANGE);
    
    			// This works fine all the time... and also send appropriate message to every top level window
    			SendMessage(new IntPtr((int)SpecialHandles.HWND_BROADCAST), WM_SYSCOMMAND, SC_SCREENSAVE, 0);
    		}
    
    		// ************************************************************************
    		private void MainWindow_OnInitialized(object sender, EventArgs e)
    		{
    			int error;
    			IntPtr hMod = LoadLibrary("user32.dll"); // Hans Passant info in stackOverflow
    
    			_hHook = SetWindowsHookEx(HookType.WH_GETMESSAGE, MessageHookProc, IntPtr.Zero, (uint)Thread.CurrentThread.ManagedThreadId);
    			error = Marshal.GetLastWin32Error(); // Error 87
    
    			_hHook = SetWindowsHookEx(HookType.WH_GETMESSAGE, MessageHookProc, hMod, (uint)Thread.CurrentThread.ManagedThreadId);
    			error = Marshal.GetLastWin32Error(); // Error 87
    
    			_hHook = SetWindowsHookEx(HookType.WH_GETMESSAGE, MessageHookProc, hMod, 0);
    			error = Marshal.GetLastWin32Error(); // Work fine, got a hook, but never receive the WM_SYSCOMMAND:SC_SCREENSAVE
    		}
    
    		// ************************************************************************
    		private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    		{
    
    		}
    
    		// ************************************************************************
    		protected override void OnSourceInitialized(EventArgs e)
    		{
    			base.OnSourceInitialized(e);
    
    			// Method 1
    
    			//IntPtr mainWindowPtr = new WindowInteropHelper(this).Handle;
    			//HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
    			//if (mainWindowSrc != null)
    			//{
    			//	mainWindowSrc.AddHook(WndProc);
    			//}
    
    			// Method 2
    			HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
    			source.AddHook(WndProc);
    
    			_hotKeyHandler = new HotKeyHandeler(this);
    			_hotKeyHandler.HotKeyPressed += _hotKeyHandler_HotKeyPressed;
    			//	_hotKeyHandler.RegisterHotKey(0, Key.NumPad0);
    
    			this.Visibility = Visibility.Hidden;
    		}
    
    		// ************************************************************************
    
    
    
    
    	}
    }
  
