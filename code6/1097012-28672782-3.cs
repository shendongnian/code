	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Linq;
	using System.Collections.Concurrent;
	using System.Runtime.InteropServices;
	using System.Diagnostics;
	namespace UIAutomation
	{
		class Program
		{
			public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
			[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
			static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
			public static bool EnumChildWindowsCallback(IntPtr hWnd, IntPtr lParam)
			{
				StringBuilder className = new StringBuilder(256);
				GetClassName(hWnd, className, className.Capacity);
				var windowInformation = new WindowInformation(hWnd, lParam, className.ToString());
				_windowLookupMap[hWnd] = windowInformation;
				if (lParam != IntPtr.Zero)
				{
					_windowLookupMap[lParam]._children.Add(windowInformation);
				}
				EnumChildWindows(hWnd, EnumChildWindowsCallback, hWnd);
				return true;
			}
			class WindowInformation
			{
				public IntPtr _parent;
				public IntPtr _hWnd;
				public string _className;
				public List<WindowInformation> _children = new List<WindowInformation>();
				public WindowInformation(IntPtr hWnd, IntPtr parent, string className)
				{
					_hWnd = hWnd;
					_parent = parent;
					_className = className;
				}
			}
			static Dictionary<IntPtr, WindowInformation> _windowLookupMap = new Dictionary<IntPtr, WindowInformation>();
			static void FindWindowsByClass(string className, WindowInformation root, ref  List<WindowInformation> matchingWindows)
			{
				if (root._className == className)
				{
					matchingWindows.Add(root);
				}
				foreach (var child in root._children)
				{
					FindWindowsByClass(className, child, ref matchingWindows);
				}
			}
			static void Main(string[] args)
			{
				var processes = Process.GetProcessesByName("notepad");
				StringBuilder className = new StringBuilder(256);
				GetClassName(processes[0].MainWindowHandle, className, className.Capacity);
				_windowLookupMap[processes[0].MainWindowHandle] = new WindowInformation(processes[0].MainWindowHandle, IntPtr.Zero, className.ToString());
				EnumChildWindows(processes[0].MainWindowHandle, EnumChildWindowsCallback, processes[0].MainWindowHandle);
				List<WindowInformation> matchingWindows = new List<WindowInformation>();
				FindWindowsByClass("Edit", _windowLookupMap.Single(window => window.Value._parent == IntPtr.Zero).Value, ref matchingWindows);
				Console.WriteLine("Found {0} matching window handles", matchingWindows.Count);
			}
		}
	}
