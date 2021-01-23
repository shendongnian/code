    public class Form1 : Form {
      [DllImport("user32")]
      private static extern int GetComboBoxInfo(IntPtr hwnd, out COMBOBOXINFO comboInfo);
      struct RECT {
        public int left, top, right, bottom;
      }
      struct COMBOBOXINFO {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public int stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndItem;
            public IntPtr hwndList;
      }
      public Form1(){
        InitializeComponent();  
        comboBox1.HandleCreated += (s, e) => {
           COMBOBOXINFO combo = new COMBOBOXINFO();
           combo.cbSize = Marshal.SizeOf(combo);
           GetComboBoxInfo(comboBox1.Handle, out combo);
           hwnd = combo.hwndList;
           init = false;
        };
      }
      bool init;
      IntPtr hwnd;
      NativeCombo nativeCombo = new NativeCombo();
      //This is to store the Rectangle info of your Icons
      //Key:  the Item index
      //Value: the Rectangle of the Icon of the item (not the Rectangle of the item)
      Dictionary<int, Rectangle> dict = new Dictionary<int, Rectangle>();
      public class NativeCombo : NativeWindow {
            //this is custom MouseDown event to hook into later
            public event MouseEventHandler MouseDown;
            protected override void WndProc(ref Message m)
            {                
                if (m.Msg == 0x201)//WM_LBUTTONDOWN = 0x201
                {                    
                    int x = m.LParam.ToInt32() & 0x00ff;
                    int y = m.LParam.ToInt32() >> 16;
                    if (MouseDown != null) MouseDown(null, new MouseEventArgs(MouseButtons.Left, 1, x, y, 0));                                                                  
                }
                base.WndProc(ref m);
            }
      }
      //DropDown event handler of your comboBox1
      private void comboBox1_DropDown(object sender, EventArgs e) {
            if (!init) {
                //Register the MouseDown event handler <--- THIS is WHAT you want.
                nativeCombo.MouseDown += comboListMouseDown;
                nativeCombo.AssignHandle(hwnd);                
                init = true;
            }
      }
      //This is the MouseDown event handler to handle the clicked icon
      private void comboListMouseDown(object sender, MouseEventArgs e){
        foreach (var kv in dict) {
          if (kv.Value.Contains(e.Location)) {
             //Show the item index whose the corresponding icon was held down
             MessageBox.Show(kv.Key.ToString());
             return;
          }
        }
      }
      //DrawItem event handler
      private void comboBox1_DrawItem(object sender, DrawItemEventArgs e) {
         //We have to save the Rectangle info of the item icons
         Rectangle rect = new Rectangle(0, e.Bounds.Top, e.Bounds.Height, e.Bounds.Height);
         dict[e.Index] = rect;
         //Draw the icon
         //e.Graphics.DrawImage(yourImage, rect);   
      }
    }
