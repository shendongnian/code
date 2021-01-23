    // base class.  Two different forms subclass this form to illustrate two
    // different solutions.
    public class FormFlash : Form {
    
    	protected Label lb = new Label { Text = "Not flashing", Dock = DockStyle.Top };
    
    	public FormFlash() {
    		Controls.Add(lb);
    
    		Thread t = new Thread(() => {
    			Thread.Sleep(3000);
    
    			if (Form.ActiveForm == this)
    				SetForegroundWindow(GetDesktopWindow()); // deactivate the current form by setting the desktop as the foreground window
    
    			this.FlashWindow(); // call extension method to flash window
    			lb.BeginInvoke((Action) delegate {
    				lb.Text = "Flashing";
    			});
    		});
    		t.IsBackground = true;
    		t.Start();
    	}
    
    
    	[DllImport("user32.dll")]
    	private static extern bool SetForegroundWindow(IntPtr hWnd);
    
    	[DllImport("user32.dll")]
    	private static extern IntPtr GetDesktopWindow();
    }
    
    // this solution is a bit simpler.  Relies on the programmer knowing when the
    // flashing started.  Uses a NativeWindow to detect when a WM_ACTIVATEAPP
    // message happens, that signals the end of the flashing.
    class FormFlashNW : FormFlash {
    
    	NW nw = null;
    	public FormFlashNW() {
    	}
    
    	protected override void OnHandleCreated(EventArgs e) {
    		base.OnHandleCreated(e);
    		nw = new NW(this.Handle, lb);
    	}
    
    	protected override void OnHandleDestroyed(EventArgs e) {
    		base.OnHandleDestroyed(e);
    		nw.ReleaseHandle();
    	}
    
    	class NW : NativeWindow {
    		Label lb = null;
    		public NW(IntPtr handle, Label lb) {
    			AssignHandle(handle);
    			this.lb = lb;
    		}
    
    		protected override void WndProc(ref Message m) {
    			base.WndProc(ref m);
    			const int WM_ACTIVATEAPP = 0x1C;
    			if (m.Msg == WM_ACTIVATEAPP) {
    				lb.BeginInvoke((Action) delegate {
    					lb.Text = "Not flashing";
    				});
    			}
    		}
    	}
    }
    
    // this solution is more complicated.  Relies on setting up the hook proc.
    // The 'isFlashing' bool fires true and false alternating while the flashing
    // is active.
    public class FormShellHook : FormFlash {
    
    	public FormShellHook() {
    		FlashWindowExListener.Register(this);
    		FlashWindowExListener.FlashEvent += FlashExListener_FlashEvent;
    	}
    
    	void FlashExListener_FlashEvent(Form f, bool isFlashing) {
    		if (f == this) {
    			lb.Text = DateTime.Now.ToLongTimeString() + " is flashing: " + isFlashing;
    		}
    	}
    }
    
    public class FlashWindowExListener {
    
    	private delegate IntPtr CallShellProc(int nCode, IntPtr wParam, IntPtr lParam);
    	private static CallShellProc procShell = new CallShellProc(ShellProc);
    	private static Dictionary<IntPtr,Form> forms = new Dictionary<IntPtr,Form>();
    	private static IntPtr hHook = IntPtr.Zero;
    
    	public static event FlashWindowExEventHandler FlashEvent = delegate {};
    	public delegate void FlashWindowExEventHandler(Form f, bool isFlashing);
    
    	static FlashWindowExListener() {
    		int processID = GetCurrentThreadId();
    
    		// we are interested in listening to WH_SHELL events, mainly the HSHELL_REDRAW event.
    		hHook = SetWindowsHookEx(WH_SHELL, procShell, IntPtr.Zero, processID);
    
    		System.Windows.Forms.Application.ApplicationExit += delegate {
    			UnhookWindowsHookEx(hHook);
    		};
    	}
    
    	public static void Register(Form f) {
    		if (f.IsDisposed)
    			throw new ArgumentException("Cannot use disposed form.");
    
    		if (f.Handle == IntPtr.Zero) {
    			f.HandleCreated += delegate {
    				forms[f.Handle] = f;				
    			};
    		}
    		else
    			forms[f.Handle] = f;
    
    		f.HandleDestroyed += delegate {
    			Unregister(f);
    		};
    	}
    
    	public static void Unregister(Form f) {
    		forms.Remove(f.Handle);
    	}
    
    	private static IntPtr ShellProc(int nCode, IntPtr wParam, IntPtr lParam) {
    
    		if (nCode == HSHELL_REDRAW) {
    			Form f = null;
    			// seems OK not having to call f.BeginInvoke
    			if (forms.TryGetValue(wParam, out f))
    				FlashEvent(f, (int) lParam == 1);
    		}
    
    		return CallNextHookEx(hHook, nCode, wParam, lParam);
    	}
    
    	private const int WH_SHELL = 10;
    	private const int HSHELL_REDRAW = 6;
    
    	[DllImport("user32.dll")]
    	private static extern int UnhookWindowsHookEx(IntPtr idHook);
    
    	[DllImport("user32.dll")]
    	private static extern IntPtr SetWindowsHookEx(int idHook, CallShellProc lpfn, IntPtr hInstance, int threadId);
    
    	[DllImport("kernel32.dll")]
    	private static extern int GetCurrentThreadId();
    
    	[DllImport("user32.dll")]
    	private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);
    }
