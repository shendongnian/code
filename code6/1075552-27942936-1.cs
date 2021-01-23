	using System;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Windows;
	using System.Windows.Controls;
	namespace stackoverflowtest
	{
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
				_hooks = new Hooks(_tb);
				_hooks.Bind();
			}
			readonly Hooks _hooks;
		}
		public class Hooks
		{
			public Hooks(TextBox textbox)
			{
				_listener = EventCallback;
				_textbox = textbox;
			}
			readonly WinEventDelegate _listener;
			readonly TextBox _textbox;
			IntPtr _result;
			public void Bind()
			{
				_result = SetWinEventHook(
					EVENT_SYSTEM_FOREGROUND,
					EVENT_SYSTEM_FOREGROUND,
					IntPtr.Zero,
					_listener,
					0,
					0,
					WINEVENT_OUTOFCONTEXT
					);
			}
			void EventCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild,
				uint dwEventThread, uint dwmsEventTime)
			{
				var windowTitle = new StringBuilder(300);
				GetWindowText(hwnd, windowTitle, 300);
				_textbox.Text = windowTitle.ToString();
			}
			#region P/Invoke
			const uint WINEVENT_OUTOFCONTEXT = 0;
			const uint EVENT_SYSTEM_FOREGROUND = 3;
			[DllImport("user32.dll")]
			static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc,
				WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
			[DllImport("user32.dll")]
			static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
			delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject,
				int idChild, uint dwEventThread, uint dwmsEventTime);
			#endregion
		}
	}
