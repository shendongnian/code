	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using System.Runtime.InteropServices;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			private ClipBoardMonitor cbm = null;
			public Form1()
			{
				InitializeComponent();
				cbm = new ClipBoardMonitor();
				cbm.NewText += cbm_NewText;
			}
			private void cbm_NewText(string txt)
			{
				Console.WriteLine(txt);
			}
		}
		public class ClipBoardMonitor : NativeWindow 
		{
			private const int WM_DESTROY = 0x2;
			private const int WM_DRAWCLIPBOARD = 0x308;
			private const int WM_CHANGECBCHAIN = 0x30d;
			[DllImport("user32.dll")]
			static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
			[DllImport("user32.dll")]
			static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
			public event NewTextEventHandler NewText;
			public delegate void NewTextEventHandler(string txt);
			private IntPtr NextClipBoardViewerHandle;
			public ClipBoardMonitor() 
			{
				this.CreateHandle(new CreateParams());
				NextClipBoardViewerHandle = SetClipboardViewer(this.Handle);
			}
			protected override void WndProc(ref Message m)
			{
				switch (m.Msg)
				{
					case WM_DRAWCLIPBOARD:
						if (Clipboard.ContainsText())
						{
							if (NewText != null)
							{
								NewText(Clipboard.GetText());
							}
						}
						SendMessage(NextClipBoardViewerHandle, m.Msg, m.WParam, m.LParam);
						break;
					case WM_CHANGECBCHAIN:
						if (m.WParam.Equals(NextClipBoardViewerHandle))
						{
							NextClipBoardViewerHandle = m.LParam;
						}
						else if (!NextClipBoardViewerHandle.Equals(IntPtr.Zero))
						{
							SendMessage(NextClipBoardViewerHandle, m.Msg, m.WParam, m.LParam);
						}
						break;
					case WM_DESTROY:
						ChangeClipboardChain(this.Handle, NextClipBoardViewerHandle);
						break;
				}
				base.WndProc(ref m);
			}
		}
	}
