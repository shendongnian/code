    // Extension class to disable the auto-select behavior when a combobox is in DropDown mode.
    public static class ComboBoxAutoSelectEx {
    
    	public static void AutoSelectOff(this ComboBox combo) {
    		Data.Register(combo);
    	}
    
    	public static void AutoSelectOn(this ComboBox combo) {
    		Data data = null;
    		if (Data.dict.TryGetValue(combo, out data)) {
    			data.Dispose();
    			Data.dict.Remove(combo);
    		}
    	}
    
    	private class Data {
    		// keep a reference to the native windows so they don't get disposed
    		internal static Dictionary<ComboBox, Data> dict = new Dictionary<ComboBox, Data>();
    
    		// a ComboBox consists of 3 windows (combobox handle, text edit handle and dropdown list handle)
    		ComboBox combo;
    		NW nwList = null; // handle to the combobox's dropdown list
    
    		internal void Dispose() {
    			dict.Remove(this.combo);
    			this.nwList.ReleaseHandle();
    		}
    
    		public static void Register(ComboBox combo) {
    
    			Data data = new Data() { combo = combo };
    			Action assign = () => {
    				COMBOBOXINFO info = new COMBOBOXINFO();
    				info.cbSize = Marshal.SizeOf(info);
    				SendMessageCb(combo.Handle, 0x164, IntPtr.Zero, out info);
    
    				dict[combo] = data;
    				data.nwList = new NW(info.hwndList);
    			};
    
    			if (!combo.IsHandleCreated)
    				combo.HandleCreated += delegate { assign(); };
    			else
    				assign();
    
    			combo.HandleDestroyed += delegate {
    				data.Dispose();
    			};
    		}
    	}
    
    	[StructLayout(LayoutKind.Sequential)]
    	private struct RECT {
    		public int Left;
    		public int Top;
    		public int Right;
    		public int Bottom;
    	}
    
    	private struct COMBOBOXINFO {
    		public Int32 cbSize;
    		public RECT rcItem;
    		public RECT rcButton;
    		public int buttonState;
    		public IntPtr hwndCombo;
    		public IntPtr hwndEdit;
    		public IntPtr hwndList;
    	}
    
    	[DllImport("user32.dll", EntryPoint = "SendMessageW", CharSet = CharSet.Unicode)]
    	private static extern IntPtr SendMessageCb(IntPtr hWnd, int msg, IntPtr wp, out COMBOBOXINFO lp);
    
    	private class NW : NativeWindow {
    		public NW(IntPtr handle) {
    			this.AssignHandle(handle);
    		}
    
            private const int LB_FINDSTRING = 0x018F;
            private const int LB_FINDSTRINGEXACT = 0x01A2;
    
    		protected override void WndProc(ref Message m) {
    			if (m.Msg == LB_FINDSTRING)
    				m.Msg = LB_FINDSTRINGEXACT;
    
    			base.WndProc(ref m);
    		}
    	}
    }
    
    // try typing 'a' in both boxes, then resizing the window
    // The top combo box will keep 'a', the bottom one will select 'Apple'
    // Similarly, try opening and closing the dropdown list, or changing focus.
    public class Form8 : Form {
    
    	ComboBox combo = new ComboBox() { Dock = DockStyle.Top }; // modified
    	Button btn1 = new Button { Text = "Set Text Button", Dock = DockStyle.Top };
    	Button btn2 = new Button { Text = "Get Text Button", Dock = DockStyle.Top };
    	Button btn3 = new Button { Text = "Get Selected Text Button", Dock = DockStyle.Top };
    	ComboBox combo1 = new ComboBox() { Dock = DockStyle.Top }; // regular
    	public Form8() {
    		combo.AutoSelectOff();
    
    		this.Controls.Add(btn3);
    		this.Controls.Add(btn2);
    		this.Controls.Add(btn1);
    		this.Controls.Add(combo1);
    		this.Controls.Add(combo);
    		combo1.Items.AddRange(new Object[] { "Apple", "Banana" });
    		combo.Items.AddRange(new Object[] { "Apple", "Banana" });
    		btn1.Click += delegate {
    			combo.Text = "Abcd";
    		};
    		btn2.Click += delegate {
    			MessageBox.Show("" + combo.Text);
    		};
    
    		btn3.MouseEnter += delegate {
    			if (combo.SelectedText.Length > 0)
    				MessageBox.Show("" + combo.SelectedText);
    		};
    	}
    }
