    //Must add using System.Runtime.InteropServices;
    public static class Win32 {
       [DllImport("user32")]
       public static extern bool GetComboBoxInfo(IntPtr hwnd, 
                                                 out Win32.COMBOBOXINFO info);
       public struct RECT {
                public int left, top, right, bottom;
       }
       public struct COMBOBOXINFO {
                public int size;
                public RECT item;
                public RECT button;
                public int state;
                public IntPtr comboHwnd;
                public IntPtr itemHwnd;
                public IntPtr listHwnd;
       }
    }
    public class CustomComboBox : ComboBox {
       NativeDropDownList dropDown = new NativeDropDownList();
       IntPtr dropDownHandle;
       bool hideDropDownAfterSelect = true;
       public CustomComboBox() {
          dropDown.ParentControl = this;
          HandleCreated += (s, e) => {
             Win32.COMBOBOXINFO info = new Win32.COMBOBOXINFO();
             info.size = Marshal.SizeOf(info);                   
             Win32.GetComboBoxInfo(Handle, out info);
             dropDownHandle = info.listHwnd;                    
          };
       }
       public bool HideDropDownAfterSelect {
          get {
             return hideDropDownAfterSelect;
          }
          set {
             if (hideDropDownAfterSelect != value) {
               hideDropDownAfterSelect = value;
               if (!value) dropDown.AssignHandle(dropDownHandle);
               else dropDown.ReleaseHandle();
             }
          }
       }
       private class NativeDropDownList : NativeWindow {
          public ComboBox ParentControl;
          protected override void WndProc(ref Message m) {
             if (m.Msg == 0x202) { //WM_LBUTTONUP                                    
                AcceptSelection(false);
                return;
             }
             //WM_LBUTTONDBLCLK
             if (m.Msg == 0x203) AcceptSelection(true);
             base.WndProc(ref m);
          }
          private void AcceptSelection(bool hideDropDown) {
             //LB_GETCURSEL = 0x188
             Message m = Message.Create(Handle, 0x188, IntPtr.Zero, IntPtr.Zero);
             WndProc(ref m);
             int i = m.Result.ToInt32();
             typeof(ComboBox).GetMethod("OnSelectedIndexChanged", 
                                       System.Reflection.BindingFlags.NonPublic | 
                                       System.Reflection.BindingFlags.Instance)
                             .Invoke(ParentControl, new object[] { EventArgs.Empty });
             if (i == -1) return;
             ParentControl.Text = ParentControl.Items[i].ToString();
             ParentControl.SelectAll();
             ParentControl.Invalidate();
             if (hideDropDown) {
                ParentControl.DroppedDown = false;
             }
          }
       }
    } 
    //Usage
    customComboBox1.HideDropDownAfterSelect = false;
    //You can select the item and hide the drop down by double-clicking left mouse
    //It works that way because of the code above at WM_LBUTTONDBLCLK
